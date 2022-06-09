using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof (Animator))]
public class Hand : MonoBehaviour
{
    public float speed;

    Animator animator;

    private float gripTarget;

    private float triggerTarget;

    private float gripCurrent;

    private float triggerCurrent;

    private string animatorGripParam = "Grip";

    private string animatorTriggerParam = "Trigger";

    void Start()
    {
        animator = GetComponent<Animator>();
        gripTarget = 0;
        triggerTarget = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }

    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        triggerTarget = v;
    }

    void AnimateHand()
    {
        if (gripTarget != gripCurrent)
        {
            gripCurrent =
                Mathf
                    .MoveTowards(gripCurrent,
                    gripTarget,
                    Time.deltaTime * speed);
            animator.SetFloat (animatorGripParam, gripCurrent);
        }
        if (triggerTarget != triggerCurrent)
        {
            triggerCurrent =
                Mathf
                    .MoveTowards(triggerCurrent,
                    triggerTarget,
                    Time.deltaTime * speed);
            animator.SetFloat (animatorTriggerParam, triggerCurrent);
        }
    }
}
