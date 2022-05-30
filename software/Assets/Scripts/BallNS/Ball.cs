using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monobehaviour which can be put on the player's controller to allow grabbing the ball by pressing the trigger when the ball is in reach.
/// </summary>
public class Ball : MonoBehaviour
{
    public GameObject nextTarget;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// SetNextTarget is a function to keep track of where our ball is going next (or should be going)
    /// </summary>
    /// <param name="target"></param>
    public void SetNextTarget(GameObject target)
    {
        nextTarget = target;
    }
    public void SetParent(Transform parent)
    {
        //transform.parent = parent;
        rb.useGravity = false;
        parent.position = transform.localPosition;
    }

    public void ReleaseBall()
    {
        transform.parent = null;
        rb.useGravity = true;
    }

    public void TossBall(Vector3 direction, float force)
    {
        GetComponent<Rigidbody>().AddForce(direction * force*10);
        ReleaseBall();
    }
}
