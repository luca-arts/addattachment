using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caregiver : MonoBehaviour
{
    public bool canBeActivated = false;
    public bool isActivated = false;
    public bool hasBeenActivated = false;
    [SerializeField] private StateManager stateManager;
    //we use the trialList to access the trials
    [SerializeField] private TrialList trialList;
    //we use the trialType to decide if we need to enable canBeActivated in pre- or postTrial.
    [SerializeField] private TrialType trialType;
    //we use the responseList to get a new response
    [SerializeField] private ResponseList responseList;


    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("stateManagerPrefab").GetComponent<StateManager>();
        trialList = GameObject.Find("trialListPrefab").GetComponent<TrialList>();
        trialType = trialList.trialType;
        responseList = GameObject.Find("responseListPrefab").GetComponent<ResponseList>();
    }

    // Update is called once per frame
    void Update()
    {
        //LOGIC TO ENABLE canBeActivated 
        if (stateManager.currentState == stateManager.preTrialState && trialType == TrialType.practical)
        {
            canBeActivated = true;
        }
        else if (stateManager.currentState == stateManager.postTrialState && trialType == TrialType.emotional)
        {
            canBeActivated = true;
        }
        //activate the caregivers responses
        if (canBeActivated && isActivated)
        {
            ReadResponse();
            isActivated = false;
        }

    }

    private void ReadResponse()
    {
        // Return a random response or do we want a curated flow? 
        // curated : trialList.currentTrial, random is Random.Range(0,trialList.numberOfTrials)
        Trial trial = trialList.GetCurrentTrial();
        bool goodOrBad = trial.IsGoodResponse();
        int responseNumber = Random.Range(0, responseList.GetLengthResponses(goodOrBad));
        string response = responseList.GetResponse(responseNumber, goodOrBad);
        Debug.Log(response);
    }
}
