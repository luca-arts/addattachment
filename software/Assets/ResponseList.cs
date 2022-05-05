using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResponseList : MonoBehaviour
{
    
    [SerializeField] private string[] goodResponses;
    [SerializeField] private string[] badResponses;
    public GameObject trialList;
    private TrialType trial;

    // Start is called before the first frame update
    void Start()
    {
        trial = trialList.GetComponent<TrialList>().trialType;
        //read file located at the relative path "Assets/Resources/EmotionalResponses.csv"
        //and store the contents in the string array "emotionalResponses"
        if (trial == TrialType.emotional)
        {
            goodResponses = Resources.Load<TextAsset>("EmotionalGood").text.Split('\n');
            badResponses =Resources.Load<TextAsset>("EmotionalBad").text.Split('\n');
        }
        else
        {
            goodResponses = Resources.Load<TextAsset>("PracticalGood").text.Split('\n');
            badResponses = Resources.Load<TextAsset>("PracticalBad").text.Split('\n');
        }

    }


    public string GetResponse(int index, bool goodOrBad)
    {
        if (goodOrBad)
        {
            return goodResponses[index];
        }
        else
        {
            return badResponses[index];
        }

    }
}
   