using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

//[RequireComponent(typeof(TMP_Text))]
public class TextPopUp : MonoBehaviour
{
    public float DestroyTime = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}