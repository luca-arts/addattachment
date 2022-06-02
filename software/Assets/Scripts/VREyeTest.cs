using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class VREyeTest : MonoBehaviour, IGazeFocusable
{
    private Material _material;

    public void GazeFocusChanged(bool hasFocus)
    {
        if (hasFocus)
        {
            _material.color = Color.cyan;
        }
        else
        {
            _material.color = Color.red;
        }
    }
}
