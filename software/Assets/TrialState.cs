using UnityEngine;

public class TrialState : StateMachine
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("Entering Trial State");
        state.trialName = "TrialState";
    }

    public override void OnCollisionEnter(StateManager state)
    {
        Debug.Log("Collision Enter");
    }

    public override void UpdateState(StateManager state)
    {
        if (state.endTrial) { state.SwitchState(state.postTrialState); }
    }

    public override void ExitState(StateManager state)
    {
        Debug.Log("Exiting Trial State");
        state.endTrial = false;
    }
}
