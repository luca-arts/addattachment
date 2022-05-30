using System;
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
    internal class BallStateMachine: MonoBehaviour
    {
        private GameObject ballOwner;
        public GameObject ball;
        private Rigidbody ballRb;
        public bool IsObjectGrabbing { get; private set; }

        private enum GrabState
        {
            Idle,
            Grabbing,
            Grabbed,
            Throw
        }

        private GrabState _currentGrabState = GrabState.Idle;


        // Fields related to animating the object flying to the hand.
        private float _grabAnimationProgress;
        private Vector3 _startPosition;
        private Quaternion _startControllerRotation;
        private Quaternion _startObjectRotation;
        private float _flyToControllerTimeSeconds;
        private AnimationCurve _animationCurve;
        

        private void Start()
        {
            ballRb = ball.GetComponent<Rigidbody>();
        }

        private void UpdateObjectState()
        {
            // If the object is the "idle" state, and the user looks at the object and presses the grab button, start moving the object to the controller.
            if (_currentGrabState == GrabState.Idle)
            {

                
                
            }

            // The object is in its "grabbing" state, meaning it's moving towards the controller.
            if (_currentGrabState == GrabState.Grabbing)
            {
                if (ballOwner.CompareTag("Child"))
                {
                    //// If the grab* button is held, move the object towards the controller using a lerp function.
                    //if (ControllerManager.Instance.GetButtonPress(TriggerButton))
                    //{
                    //    _grabAnimationProgress += Time.deltaTime / _flyToControllerTimeSeconds;
                    //    _grabbedObjectRigidBody.position = Vector3.Lerp(_startPosition, ControllerManager.Instance.Position,
                    //        _animationCurve.Evaluate(_grabAnimationProgress));

                    //    // If the distance between the controller and the object is close enough, grab the object.
                    //    if (Vector3.Distance(_grabbedObjectRigidBody.position, ControllerManager.Instance.Position) <
                    //        ObjectSnapDistance)
                    //    {
                    //        ChangeObjectState(GrabState.Grabbed);
                    //    }
                    //}
                    //// If the grab button is released, drop the object.
                    //else if (!ControllerManager.Instance.GetButtonPress(TriggerButton))
                    //{
                    //    ChangeObjectState(GrabState.Idle);
                    //}
                }
                else
                {
                    // the ball should move from the hand of the current owner, to the hand of the new owner
                }
            }

            // If the object is currently being grabbed and the grab button is released, apply the controller's velocity to the object and invoke OnObjectReleased.
            if (_currentGrabState == GrabState.Grabbed)
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
                    // the ball is attached to the hand of the current owner, and should be thrown away after a given time
                }
            }
        }

        /// <summary>
        /// Called when the object transitions from one <see cref="GrabState"/> to another.
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
                case GrabState.Grabbing:
                    IsObjectGrabbing = true;
                    //ball.ObjectGrabbing();
                    ballRb.isKinematic = true;
                    _startObjectRotation = ball.transform.rotation;
                    //_startControllerRotation = ControllerManager.Instance.Rotation;
                    _startPosition = ball.transform.position;
                    _grabAnimationProgress = 0f;
                    break;
                // When the object becomes grabbed to the controller, call the grabbed method and set the object's position to the hand.
                case GrabState.Grabbed:
                    //ControllerManager.Instance.TriggerHapticPulse(0.25f);
                    //ball.ObjectGrabbed();
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
                    }
                    
                    break;
                // when the user releases the ball throw it, if it's an NPC who's throwing the ball, we have to calculate the trajectory of the ball.
                case GrabState.Throw:
                    if (ballOwner.CompareTag("Child"))
                    {
                    }
                    else
                    {
                        ballRb.useGravity = true;
                        //ballRb.velocity = Vector3.zero;
                        ball.transform.parent = null;
                    }
                    break;
            }
        }
    }
}
