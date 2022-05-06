using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class StateMgrTest
{
    GameObject stateMgr;
    StateManager state;

    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]
    public IEnumerator WalkThroughStates()
    {
        stateMgr = GameObject.Find("stateManagerPrefab");
        state = GameObject.Find("stateManagerPrefab").GetComponent<StateManager>();

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //yield return null;
        Assert.IsNotNull(stateMgr);
        Assert.IsNotNull(state);
        Assert.AreEqual(state.currentState, state.preTrialState);

        state.startTrial = true;
        yield return 1;
        Assert.AreEqual(state.currentState, state.trialState);
        Assert.AreEqual(state.startTrial, false);

        state.endTrial = true;
        yield return 1;
        Assert.AreEqual(state.currentState, state.postTrialState);
        Assert.AreEqual(state.endTrial, false);

        state.restart = true;
        yield return 1;
        Assert.AreEqual(state.currentState, state.preTrialState);
        Assert.AreEqual(state.restart, false);
    }
}
