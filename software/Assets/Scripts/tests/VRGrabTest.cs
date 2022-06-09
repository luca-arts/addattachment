using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Make sure to add Unity.XR.Interaction to the assembly
/// This is a file to test catching the left hand and right hand controller script
/// </summary>
public class VRGrabTest : MonoBehaviour
{
    private XRGrabInteractable xR;
    public XRRayInteractor xRRayLeft;
    public XRRayInteractor xRRayRight;

    private float _switchTime = 2.0f;
    private float _runningTime = 0.0f;
    private float _shortDistance = 2.5f;
    private float _longDistance= 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        xR = GetComponent<XRGrabInteractable>();
        xRRayLeft.maxRaycastDistance = _shortDistance;
        xRRayRight.maxRaycastDistance = _longDistance;
        
    }

    // Update is called once per frame
    void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime >= _switchTime)
        {
            _runningTime = 0.0f;
            if (xRRayLeft.maxRaycastDistance == _shortDistance)
            {
                xRRayLeft.maxRaycastDistance = _longDistance;
                xRRayRight.maxRaycastDistance = _shortDistance;
            }
            else
            {
                xRRayLeft.maxRaycastDistance = _shortDistance;
                xRRayRight.maxRaycastDistance = _longDistance;
            }
        }
    }
}
