using UnityEngine;

public class PreTrialState : StateMachine
{
    public override void EnterState(StateManager state)
    {
        Debug.Log("Entering PreTrialState");
        state.trialName = "preTrial";
    }

    public override void OnCollisionEnter(StateManager state)
    {
        Debug.Log("Collision Enter");
    }

    public override void UpdateState(StateManager state)
    {
        if (state.startTrial)
        {
            state.SwitchState(state.trialState);
        }
    }

    public override void ExitState(StateManager state)
    {
        Debug.Log("Exiting PreTrialState");
        state.startTrial = false;
    }
}
