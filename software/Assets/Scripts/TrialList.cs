using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public Trial GetCurrentTrial()
    {
        return trialsList[currentTrial];
    }

    public void NextTrial()
    {
        currentTrial++;
    }
}
