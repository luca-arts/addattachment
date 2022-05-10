using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject popUpTextPrefab;
    public Vector3 textOffset = new Vector3(0, 2, 0);
    
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
            string response = ReadResponse();
            isActivated = false;
            GiveResponse(response, textOffset);

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

    /// <summary>
    /// a function that instantiates a pop up text prefab and sets the text to the response
    /// </summary>
    /// <param name="response"></param>
    public void GiveResponse(string response, Vector3 offset) 
    {
        if (popUpTextPrefab)
        {
            GameObject popUpText = Instantiate(popUpTextPrefab, transform.position + offset, Quaternion.identity, transform);
            popUpText.GetComponent<Renderer>().material.color = Color.gray;
            popUpText.GetComponentInChildren<TextMeshPro>().color = Color.red;
            popUpText.GetComponentInChildren<TextMeshPro>().text = response;
            popUpText.GetComponentInChildren<TextMeshPro>().enableAutoSizing = true;
            popUpText.transform.LookAt(popUpText.transform.position - Camera.main.transform.position);
            // have it dissapear when clicked? Now it dissapears in textpopup.cs
        }
        else
        {
            Debug.Log("No pop up text prefab");
        }

    }
}
