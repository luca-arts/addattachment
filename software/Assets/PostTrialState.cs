using UnityEngine;

public class PostTrialState : StateMachine
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("Entering PostTrialState");
        state.trialName = "PostTrialState";
    }

    public override void OnCollisionEnter(StateManager state)
    {
        Debug.Log("Collision Enter");
    }

    public override void UpdateState(StateManager state)
    {
        if (state.restart) { state.SwitchState(state.preTrialState); }
    }

    public override void ExitState(StateManager state)
    {
        Debug.Log("Exiting PostTrialState");
        state.restart = false;
    }
}
