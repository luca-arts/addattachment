using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ResponseEvent : UnityEvent<string>
{
    public string response;
}

public class CaregiverResponse : MonoBehaviour
{
    public bool canBeActivated = false;
    public bool isActivated = false;
    public bool hasBeenActivated = false;
    private StateManager stateManager;
    //we use the trialList to access the trials
    private TrialList trialList;
    //we use the trialType to decide if we need to enable canBeActivated in pre- or postTrial.
    private TrialType trialType;
    //we use the responseList to get a new response
    private ResponseList responseList;
    //we launch an event with the popup when the caregiver is activated
    [SerializeField] private ResponseEvent onActivate;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("stateManagerPrefab").GetComponent<StateManager>();
        trialList = GameObject.Find("trialListPrefab").GetComponent<TrialList>();
        responseList = GameObject.Find("responseListPrefab").GetComponent<ResponseList>();
        trialType = trialList.trialType;
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
            string response = ReadResponse();
            isActivated = false;
            // we launch a unity event to show the response in a popup
            onActivate?.Invoke(response);
        }

    }
    /// <summary>
    /// This function reads a response from the responseList and sets the caregiver's response to this response
    /// </summary>
    private string ReadResponse()
    {
        // Return a random response or do we want a curated flow? 
        // curated : trialList.currentTrial, random is Random.Range(0,trialList.numberOfTrials)
        Trial trial = trialList.GetCurrentTrial();
        bool goodOrBad = trial.IsGoodResponse();
        int responseNumber = Random.Range(0, responseList.GetLengthResponses(goodOrBad));
        string response = responseList.GetResponse(responseNumber, goodOrBad);
        Debug.Log(response);
        return response;
    }
}

