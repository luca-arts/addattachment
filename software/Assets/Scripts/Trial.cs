using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trial
{
    [SerializeField] private int trialNumber; // the number of the trial
    [SerializeField] private bool isGoodTrial; // true if the trial is a good trial, false if it is a bad trial
    [SerializeField] private bool isGoodResponse; // true if the caregiver must give a supportive/useful feedback, false if negative feedback.
    [SerializeField] private TrialType trialType; // emotional or practical

    public void createTrial(int trialNumber, bool isGoodTrial, bool isGoodResponse, TrialType trialType)
    {
        this.trialNumber = trialNumber;
        this.isGoodTrial = isGoodTrial;
        this.isGoodResponse = isGoodResponse;
        this.trialType = trialType;
    }

    public int GetTrialNumber() { return this.trialNumber; }
    public bool IsGoodTrial() { return this.isGoodTrial; }
    public bool IsGoodResponse() { return this.isGoodResponse; }
    public TrialType GetTrialType() { return this.trialType; }

}
public enum TrialType
{
    emotional,
    practical
}