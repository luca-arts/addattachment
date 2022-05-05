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
    
}
public enum TrialType
{
    emotional,
    practical
}


public class TrialList : MonoBehaviour
{
    public TrialType trialType; // emotional or practical
    public int contingencyLevel; // between 0 and 100
    public int numberOfTrials; // TBD
    [SerializeField] private List<Trial> trialsList; // list of trials to be used in block of experiment
    public int currentTrial; // where we are currently in the block

    // Start is called before the first frame update
    void Start()
    {
        trialsList = new List<Trial>();
        for (int i = 0; i < numberOfTrials; i++)
        {
            Trial newTrial = new Trial();

            newTrial.createTrial(
                i,
               /*isGoodTrial is true for contingencyLevel percent of the time*/
               (Random.Range(0, 100) < contingencyLevel), //TODO check if this is the intended behaviour!
                (Random.Range(0, 100) < contingencyLevel),//TODO check if this is the intended behaviour!
                trialType
            );
            trialsList.Add(newTrial);
        }
        currentTrial = 0;
    }

    public void nextTrial()
    {
        currentTrial++;
    }
}
