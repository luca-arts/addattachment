using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;
using Tobii.XR;
using UnityEngine.Events;

[System.Serializable]
public class GazeEvent : UnityEvent<float, string>
{
}



public class GazeFocus : MonoBehaviour, IGazeFocusable
{
    [SerializeField] UnityEvent m_GazeActivedEvent;
    [SerializeField] UnityEvent m_GazeDeactivedEvent;


    public void GazeFocusChanged(bool hasFocus)
    {
        // if hasFocus is true; create a unity event
        // start unity event
        if (hasFocus)
        {

            Debug.Log("Gaze Focus Changed to true");
            m_GazeActivedEvent?.Invoke();

        }
        else
        {

            Debug.Log("Gaze Focus Changed to false");
            m_GazeDeactivedEvent?.Invoke();
        }
        // if has focus becomes false, start coroutine for countdown to start another unity event
    }
}
