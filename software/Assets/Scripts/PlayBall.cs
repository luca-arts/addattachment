using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//TODO check https://www.youtube.com/watch?v=Qzgyq5Youd0&ab_channel=bugzilla2001

public class PlayBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject NPC;
    public GameObject Child;


    public float speed = 2.0f;
    //attractDist is the disance at which the ball will start to attract
    public float attractDist = 2.0f;

    //attractForce is the force at which the ball will be attracted
    public float attractForce = 800.0f;
    //repelForce is the force at which the ball will be repelled by the player TOWARDS the other player or child
    public float repelForce = 500.0f;

    //based on the isGoodTrial boolean we decide if we need to pass to the NPC or to either NPC/child
    private bool isGoodTrial;
    [SerializeField] private Trial currentTrial;

    public Vector3 collision = Vector3.zero;
    public GameObject lastHit;
    private FixedJoint currentJoint;
    private Quaternion _lookRotation;

    public bool isTossed = false;

    // Start is called before the first frame update
    void Start()
    {
        TrialList trialList = GameObject.Find("trialListPrefab").GetComponent<TrialList>();
        //wait for the trial list to be filled
        currentTrial = trialList.GetCurrentTrial();
        isGoodTrial = currentTrial.IsGoodTrial();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentJoint != null)
        {
            if (isGoodTrial)
            {
                float coinToss = Random.Range(0.0f, 1.0f);
                if (coinToss > 0.5) //TODO define a useful value?
                {
                    Debug.Log("next is child");
                    TossBall(Child);
                }
                else
                {
                    Debug.Log("next is " + NPC.name);
                    TossBall(NPC);
                }
            }
            else
            {
                Debug.Log("next is " + NPC.name);
                TossBall(NPC);
            }
        }
        else
        {
            //if the ball has been tossed, we don't want to attract it right away
            if (!isTossed)
            {
                if ((ball.transform.position - transform.position).magnitude < attractDist && !currentJoint)
                {
                    AttractBall();
                }
            }
        }
    }

    //function TossBall adds a force to the gameobject ball in the direction of a variable gameobject called partner, (in future from hand child). 

    void TossBall(GameObject partner)
    {
        //first we want to rotate the player towards the partner and then toss the ball towards the partner.
        _lookRotation = Quaternion.LookRotation((partner.transform.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, speed * Time.deltaTime);
        // then we check if we're aimed at the other player
        RaycastHit hit;
        var ray = new Ray(this.transform.position, partner.transform.position - this.transform.position);
        if (Physics.Raycast(ray, out hit, 50.0f, layerMask: LayerMask.GetMask("Player")))
        {
            Debug.DrawRay(transform.position, partner.transform.position - this.transform.position * hit.distance, Color.blue);

            if (hit.collider.gameObject == partner)
            {
                //if we are, we add a force to the ball aimed at the partner
                {
                    collision = hit.point;
                    if (hit.collider.gameObject == partner)
                    {
                        Vector3 direction = partner.transform.position - this.transform.position;
                        Destroy(currentJoint);
                        ball.GetComponent<Rigidbody>().AddForce(direction.normalized * repelForce);
                        //we enable the lookatconstraint again
                        this.GetComponent<LookAtConstraint>().constraintActive = true;
                        //we set the ball to tossed, so we don't attract it again
                        isTossed = true;
                    }
                }
            }
        }
    }

    //function attractBall adds a force to the gameobject ball in the direction of this transform
    void AttractBall()
    {
        RaycastHit hit;
        var ray = new Ray(this.transform.position, ball.transform.position - this.transform.position);
        if (Physics.Raycast(ray, out hit, attractDist, layerMask: LayerMask.GetMask("Ball")))
        {   
            if (hit.collider.gameObject == ball)
            {
                Debug.DrawRay(transform.position, (ball.transform.position - this.transform.position) * hit.distance, Color.yellow);
                {
                    lastHit = hit.transform.gameObject;
                    collision = hit.point;
                    var step = speed * Time.deltaTime;
                    ball.transform.position = Vector3.MoveTowards(ball.transform.position, transform.position, step);
                    
                    //draw a line to make it clear that the ball is attracted to the player
                    LineRenderer lineRenderer = ball.GetComponent<LineRenderer>();
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, ball.transform.position);
                }
            }
        }
    }

    /// <summary>
    /// when the ball collides with the player or child, we want to create a joint between the ball and the player or child
    /// also, we want to put the lookat constraint on inactive until we toss the ball
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            currentJoint = collision.gameObject.AddComponent<FixedJoint>();
            currentJoint.connectedBody = this.GetComponent<Rigidbody>();
            this.GetComponent<LookAtConstraint>().constraintActive = false;
            //we put the isTossed variable of the other players to false, so they can attract the ball
            NPC.GetComponent<PlayBall>().isTossed = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (collision != Vector3.zero)
        {
            Gizmos.DrawWireSphere(collision, 0.2f);
        }
    }
}
