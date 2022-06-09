using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// Monobehaviour which can be put on the player's controller to allow grabbing the ball by pressing the trigger when the ball is in reach.
/// </summary>
public class Ball : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    [SerializeField] private GameObject currentTarget;
    public bool doToss = false;
    public bool isCatched = false;
    private Rigidbody rb;

    private float tripTime = 1.5f;
    private float startTime = 0.0f;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentTarget = player2;
    }


    private void Update()
    {
        if (isCatched)
        {
            doToss = true;
            isCatched = false;
            startTime = Time.time;
            startPosition = transform.position;
            endPosition = currentTarget.transform.position;
            ReleaseBall();

            TossBall();
        }
        if (doToss)
        {
            // TossBall(nextTarget);
            TossBall();
        }
    }
    /// <summary>
    /// SetNextTarget is a function to keep track of where our ball is going next (or should be going)
    /// </summary>
    /// <param name="target"></param>
    public void SetNextTarget()
    {
        if (currentTarget == player1)
        {
            currentTarget = player2;
        }
        else
        {
            currentTarget = player1;
        }
    }

    public void SetParent(Transform parent)
    {
        transform.parent = parent;
        // rb.useGravity = false;
        transform.localPosition= parent.position;
        rb.velocity = Vector3.zero;
    
        }

    public void ReleaseBall()
    {
        transform.parent = null;
        // rb.useGravity = true;
    }

    private void TossBall()
    {
        var t = (Time.time - startTime) / tripTime;
        transform.position = Vector3.Slerp(startPosition, endPosition, t);
        if (t >= tripTime)
        {
            doToss = false;
            // SetParent(currentTarget.transform); // I Believe this could be the wrong target, OR we're having a race condition for setting the next target
            SetNextTarget();
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("collision with "+other.gameObject.name);
        SetParent(other.gameObject.transform);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("triggered with "+other.gameObject.name);
        SetParent(other.gameObject.transform);
    }

}
