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
    /// <summary>
    /// returns the length of responses written in the response file.
    /// </summary>
    /// <param name="goodorBad">a boolean to choose good (True) or bad (False) responses</param>
    /// <returns>an integer defining the length</returns>
    public int GetLengthResponses(bool goodorBad)
    {
        if (goodorBad)
        {
            return goodResponses.Length;
        }
        else
        {
            return badResponses.Length;
        }
    }
    /// <summary>
    /// returns the response at line 'index' from the good or bad response lists.
    /// </summary>
    /// <param name="index">which row, should be less than the max length</param>
    /// <param name="goodOrBad">true: Good responses, false: bad responses</param>
    /// <returns>a string</returns>
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
   