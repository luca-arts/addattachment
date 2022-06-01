using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Tobii.XR;

namespace Assets.Scripts.BallNS
{
    /// <summary>
    /// class to determine the state in which the ball is, making it possible to grab as well as throw the ball away
    /// </summary>
    internal class BallStateMachine : MonoBehaviour
    {
        private GameObject ballOwner;
        private GameObject ball;
        private Rigidbody ballRb;
        public bool IsObjectGrabbing { get; private set; }

        [SerializeField] private GameObject nextTarget; // nextTarget should get it's value from the ball's script
        public GameObject player1;
        public GameObject player2;
        private enum GrabState
        {
            Idle,
            Attract,
            Attach,
            Throw
        }

        private GrabState _currentGrabState = GrabState.Idle;


        // Fields related to animating the object flying to the hand.
        private float _grabAnimationProgress;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private Quaternion _startControllerRotation;
        private Quaternion _startObjectRotation;
        private float _flyToControllerTimeSeconds = 0.8f;
        private AnimationCurve _animationCurve;
        private GameObject _grabbedObject;
        private bool ballHasTriggered = false; // a boolean which is being set to true when the ball triggers the nextTargets ballCatcher collider
        private float idleTime = 0.0f;
        public float maxIdleTime = 2.0f;
        public float maxNPCIdleTime = 1.0f;
        [Tooltip("Time in seconds for the object to fly to controller.")] public float tripTime = 0.3f;
        private float _startThrowTime;
        public float attractDist = 0.4f;

        private void Start()
        {
            ball = GameObject.Find("Ball");
            ballRb = ball.GetComponent<Rigidbody>();
            _currentGrabState = GrabState.Attach;
            nextTarget = player1;
            ballOwner = player1;
        }

        private void Update()
        {
            UpdateObjectState();
        }

        /// <summary>
        /// UpdateObjectState decides WHEN to switch states
        /// </summary>
        private void UpdateObjectState()
        {
            // If the object is the "idle" state, and the user looks at the object and presses the grab button, start moving the object to the controller.
            if (_currentGrabState == GrabState.Idle)
            {
                // the ball can only fall into the idle state if the child did throw the ball badly
                idleTime += Time.deltaTime;
                if (idleTime > maxIdleTime)
                {
                    // TODO: destroy the ball
                    // TODO: spawn a new ball at the hand of a random player
                    ChangeObjectState(GrabState.Attach);
                }

            }

            // The object is in its "grabbing" state, meaning it's moving towards the controller.
            if (_currentGrabState == GrabState.Attract)
            {
                if (nextTarget.CompareTag("Child"))
                {
                    // If the grab* button is held, move the object towards the controller using a lerp function.
                    // if (ControllerManager.Instance.GetButtonPress(TriggerButton))
                    // {
                    //    _grabAnimationProgress += Time.deltaTime / _flyToControllerTimeSeconds;
                    //    _grabbedObjectRigidBody.position = Vector3.Lerp(_startPosition, ControllerManager.Instance.Position,
                    //        _animationCurve.Evaluate(_grabAnimationProgress));

                    //    // If the distance between the controller and the object is close enough, grab the object.
                    //    if (Vector3.Distance(_grabbedObjectRigidBody.position, ControllerManager.Instance.Position) <
                    //        ObjectSnapDistance)
                    //    {
                    //        ChangeObjectState(GrabState.Grab);
                    //    }
                    // }
                    // // If the grab button is released, drop the object.
                    // else if (!ControllerManager.Instance.GetButtonPress(TriggerButton))
                    // {
                    //    ChangeObjectState(GrabState.Idle);
                    // }
                }
                else
                {
                    ball.transform.position = TossBall(_startThrowTime, tripTime, _startPosition, _endPosition);
                    // if the ball triggers the ballCatcher gameobject we switch states
                    if (ballHasTriggered)
                    {
                        Debug.Log("switching to attach");
                        ChangeObjectState(GrabState.Attach);
                    }
                }
            }
            // if the ball is in the "grabbed" state, the ball is attached to the controller or the hand of the NPC once it collides
            if (_currentGrabState == GrabState.Attach)
            {
                if (ballOwner.CompareTag("Child"))
                {
                    //// if the grab button is released, apply the controller's velocity to the object and invoke onobjectreleased.
                    //if (!controllermanager.instance.getbuttonpress(triggerbutton))
                    //{
                    //    _grabbedobjectrigidbody.velocity = controllermanager.instance.velocity;
                    //    _grabbedobjectrigidbody.angularvelocity = controllermanager.instance.angularvelocity;
                    //    onobjectreleased();
                    //}

                    //if (ControllerManager.Instance.GetButtonPress(TriggerButton))
                    //{
                    //    // Keeps the object's original rotation as a starting point, and is otherwise locked to the controller
                    //    _grabbedObjectRigidBody.rotation =
                    //        (ControllerManager.Instance.Rotation * Quaternion.Inverse(_startControllerRotation)) *
                    //        _startObjectRotation;
                    //    _grabbedObjectRigidBody.position = ControllerManager.Instance.Position;
                    //}
                    //else
                    //{
                    //    _grabbedObjectRigidBody.angularVelocity =
                    //        ControllerManager.Instance.AngularVelocity * ObjectVelocityMultiplier;
                    //    _grabbedObjectRigidBody.velocity = ControllerManager.Instance.Velocity * ObjectVelocityMultiplier;

                    //    if (OnObjectReleased != null)
                    //    {
                    //        OnObjectReleased.Invoke(_grabbedObject.gameObject);
                    //    }

                    //    ChangeObjectState(GrabState.Idle);
                    //}
                }
                else
                {
                    // the ball is attracted to the hand of the current owner, and should be thrown away after a given time
                    idleTime += Time.deltaTime;
                    if (idleTime >= maxNPCIdleTime)
                    {
                        Debug.Log("switching to throw");
                        ChangeObjectState(GrabState.Throw);
                    }
                }
            }

            // If the object is currently being grabbed and the grab button is released, apply the controller's velocity to the object and invoke OnObjectReleased.
            if (_currentGrabState == GrabState.Throw)
            {
                if (ballOwner.CompareTag("Child"))
                {
                    //we've thrown the ball and now it should move by itself
                    ChangeObjectState(GrabState.Idle);
                }
                else
                {
                    var _pos = TossBall(_startThrowTime, tripTime, _startPosition, _endPosition);
                    ball.transform.position = _pos;
                    Debug.Log("new position = " + _pos);
                    var _dist = (nextTarget.transform.position - ball.transform.position).magnitude;
                    Debug.Log("dist: " + _dist);
                    // the ball is moving from the previous owner to the new target, as soon it's in reach, we switch states
                    if (_dist <= attractDist)
                    {
                        Debug.Log("switching to attract");
                        ChangeObjectState(GrabState.Attract);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the object transitions from one <see cref="GrabState"/> to another.
        /// Decides what should happen when the object changes states.
        /// </summary>
        /// <param name="state">The state the object should transition to.</param>
        private void ChangeObjectState(GrabState state)
        {
            _currentGrabState = state;

            switch (state)
            {
                // Inform the object that it has been ungrabbed and set it to not be kinematic.
                case GrabState.Idle:
                    IsObjectGrabbing = false;
                    //ball.ObjectUngrabbed();
                    ballRb.isKinematic = false;
                    break;
                // When the user starts grabbing the object, save the object and store its animation values.
                case GrabState.Attract:
                    // the ball is in reach of the nextTarget so we want to attract it via a SLERP as a start TODO: visualise this
                    // WE REUSE THE THROW FUNCTION FOR NOW. REWRITE TO AN ATTRACT FUNCTION (if ball comes from child)


                    IsObjectGrabbing = true;
                    //ball.ObjectGrabbing();
                    ballRb.isKinematic = true;
                    _startObjectRotation = ball.transform.rotation;
                    //_startControllerRotation = ControllerManager.Instance.Rotation;
                    _startPosition = ball.transform.position;
                    _grabbedObject = ball;
                    ballRb.isKinematic = true;
                    _grabAnimationProgress = 0f;
                    break;
                // When the object becomes grabbed to the controller, call the grabbed method and set the object's position to the hand.
                case GrabState.Attach:
                    //ControllerManager.Instance.TriggerHapticPulse(0.25f);
                    //ball.ObjectGrabbed();
                    ballOwner = nextTarget;
                    if (ballOwner.CompareTag("Child"))
                    {
                        //ball.transform.position = ControllerManager.Instance.Position;
                    }
                    else
                    {
                        ballRb.useGravity = false;
                        ballRb.velocity = Vector3.zero;
                        ball.transform.parent = ballOwner.transform;
                        ball.transform.localPosition = Vector3.zero;
                        ball.transform.localRotation = Quaternion.identity;
                        //ball.transform.position = ballOwner.transform.position;
                        idleTime = 0.0f;
                    }

                    break;
                // when the user releases the ball throw it, if it's an NPC who's throwing the ball, we have to calculate the trajectory of the ball.
                case GrabState.Throw:
                    if (ballOwner.CompareTag("Child"))
                    {
                        idleTime = 0.0f;

                    }
                    else
                    {
                        // TODO: Decide next target first
                        SetNextTarget();
                        // ballRb.useGravity = true;
                        //ballRb.velocity = Vector3.zero;
                        ball.transform.parent = null;

                        _startThrowTime = Time.time;
                        _startPosition = transform.position;
                        _endPosition = nextTarget.transform.position;
                    }
                    break;
            }
        }

        private Vector3 TossBall(float startTime, float tripTime, Vector3 mStartPosition, Vector3 mEndPosition)
        {
            var t = (Time.time - startTime) / tripTime;
            var pos = Vector3.Slerp(mStartPosition, mEndPosition, t);
            return pos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))//TODO: BallCatcher
            {
                ballHasTriggered = true;
            }
        }

        /// <summary>
        /// TODO: TEMPORARY FUNCTION
        /// SetNextTarget is a function to keep track of where our ball is going next (or should be going)
        /// </summary>
        /// <param name="target"></param>
        private void SetNextTarget()
        {
            Debug.Log("Setting next target");
            if (nextTarget == player1)
            {
                nextTarget = player2;
            }
            else
            {
                nextTarget = player1;
            }
        }
    }
}
