using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// RecordMetrics is a class which we'll use to save all metrics belonging to a certain person in a JSON format
/// </summary>
public class RecordMetrics: MonoBehaviour
{
    [SerializeField] private List<GazeEntry> gazeEntryList = new List<GazeEntry>();

    public int GetGazeEntryCount()
    {
        return gazeEntryList.Count;
    }


    public void SaveGazeEntries(float duration, string startTime) {
        GazeEntry gazeEntry = new GazeEntry(startTime, duration);
        gazeEntryList.Add(gazeEntry);
    }
    
    void OpenJsonFile(string pathToJsonFile)
    {
        // open the file at the given path and read the contents
        // then parse the contents into a JSON object
        // then close the file
        
    }

    void WriteMetricsTrial() { }
    
}

[Serializable]
public class Metrics
{ 
    
}

/// <summary>
/// GazeEntry is an entry of **when** the child did watch the caregiver and for **how long**
/// </summary>
[Serializable]
public class GazeEntry: UnityEvent<float, string>
{
    public string startTime;
    public float duration;

    public GazeEntry(string startTime, float duration)
    {
        this.startTime = startTime;
        this.duration = duration;
    }
}
