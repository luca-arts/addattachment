using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaregiverActivation : MonoBehaviour
{
    private const string GazeEventTooltip = "link metricsRecord file, this event writes the gazeEvent away";
    [SerializeField, Tooltip(GazeEventTooltip)] GazeEvent m_updateGaze = new();

    private string gazeStartTime = "";
    private float gazeDuration = 0f;
    private float startTime = 0f;
    [SerializeField] private bool isActivated;
    [SerializeField] private bool canBeActivated;
    
    public void ActivateCaregiver()
    {
        isActivated = GetComponent<CaregiverResponse>().isActivated;
        canBeActivated = GetComponent<CaregiverResponse>().canBeActivated;
        if (canBeActivated)
        {
            isActivated = true;         
        }
        gazeStartTime = System.DateTime.Now.ToString("HH:mm:ss.fff");
        startTime = Time.time;
    }

    /// <summary>
    /// DeactivateCaregiver writes the gazeEvent to the file
    /// TODO this function can also be used to destroy the popup if we don't want to destroy it timed
    /// </summary>
    public void DeactivateCaregiver()
    {
        Debug.Log("Deactivating caregiver");
        gazeDuration = Time.time - startTime;
        m_updateGaze?.Invoke(gazeDuration, gazeStartTime);
    }
}
