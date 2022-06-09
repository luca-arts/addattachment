using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStateMgrManual : MonoBehaviour
{
    private StateManager statemgr;
    private string stateMgrName = "stateManagerPrefab";
    void Start()
    {
        statemgr = GameObject.Find(stateMgrName).GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartTrial(){
        statemgr.SwitchState(statemgr.trialState);
    }
    public void EndTrial(){
        statemgr.SwitchState(statemgr.postTrialState);
    }

    public void RestartTrial(){
        statemgr.SwitchState(statemgr.preTrialState);
    }
}
