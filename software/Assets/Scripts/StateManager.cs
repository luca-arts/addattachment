using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference: https://www.youtube.com/watch?v=Vt8aZDPzRjI
public class StateManager : MonoBehaviour
{
    public StateMachine currentState;
    public PreTrialState preTrialState = new PreTrialState();
    public TrialState trialState = new TrialState();
    public PostTrialState postTrialState = new PostTrialState();

    public bool startTrial = false;
    public bool endTrial = false;
    public bool restart = false;
    // trialName is for debugging purposes
    public string trialName;

    // Start is called before the first frame update
    void Start()
    {
        // starting state for our state machine
        currentState = preTrialState;
        trialName = "PreTrial";
        // "this" is a reference to the context (this EXACT Monobehavior script)
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(StateMachine newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
