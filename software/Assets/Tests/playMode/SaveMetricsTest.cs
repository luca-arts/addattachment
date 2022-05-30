using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SaveMetricsTest
{
    GameObject caregiver;
    GameObject metrics;
    GameObject stateMgr;
    StateManager state;

    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("DemoScene");
    }

    [UnityTest]
    public IEnumerator SaveMetricsTestSimplePasses()
    {
        caregiver = GameObject.Find("Caregiver");
        metrics = GameObject.Find("recordMetrics");
        stateMgr = GameObject.Find("stateManagerPrefab");
        state = GameObject.Find("stateManagerPrefab").GetComponent<StateManager>();
        state.startTrial = true;
        yield return new WaitForSeconds(1);
        state.endTrial = true;
        yield return new WaitForSeconds(1);
        Assert.AreEqual(state.currentState, state.postTrialState);
        Assert.AreEqual(state.endTrial, false);
        
        Assert.IsNotNull(caregiver);
        var caregiverResponse = caregiver.GetComponentInChildren<CaregiverResponse>();
        var caregiverActivation = caregiver.GetComponentInChildren<CaregiverActivation>();
        var gazeFocus = caregiver.GetComponentInChildren<GazeFocus>();
        var gazeEntryList = metrics.GetComponentInChildren<RecordMetrics>();
        var responsePopup = caregiver.GetComponentInChildren<ResponsePopUp>();
        Assert.IsNotNull(gazeFocus);
        caregiverResponse.canBeActivated = true;
        gazeFocus.GazeFocusChanged(true);
        yield return new WaitForSeconds(1);
        gazeFocus.GazeFocusChanged(false);
        yield return new WaitForSeconds(responsePopup.DestroyTime+0.5f);
        var res = gazeEntryList.GetGazeEntryCount();
        Assert.IsTrue(res > 0);


    }


}
