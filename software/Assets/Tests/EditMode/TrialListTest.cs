using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrialListTest
{
    TrialList trialList;
    GameObject trialListPrefab;
    // A Test behaves as an ordinary method
    [Test]
    public void TestTrialListInspectorElements()
    {
        trialListPrefab = GameObject.Find("trialListPrefab");
        trialList = trialListPrefab.GetComponent<TrialList>();
        // Use the Assert class to test conditions
        Assert.IsNotNull(trialListPrefab); // check whether there's a gameObject
        Assert.IsNotNull(trialList.trialType);
        Assert.IsNotNull(trialList.contingencyLevel);
        Assert.IsTrue(trialList.contingencyLevel >= 0 && trialList.contingencyLevel <= 100);
    }

}
