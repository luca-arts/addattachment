using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ResponsePopUp : MonoBehaviour
{

    [SerializeField] private Vector3 textOffset = new(0, 2, 0);
    public float DestroyTime = 3.0f;
    public GameObject popUpTextPrefab;
    private GameObject child;

    private void Start()
    {
        child = GameObject.FindGameObjectWithTag("Child");
    }
    /// <summary>
    /// a function that instantiates a pop up text prefab and sets the text to the response
    /// TODO PLACE THIS IN A UNITY EVENT?
    /// </summary>
    /// <param name="response"></param>
    public void GiveResponse(string response)
    {
        if (popUpTextPrefab)
        {
            GameObject popUpText = Instantiate(popUpTextPrefab, transform.position + textOffset, Quaternion.identity, transform);
            popUpText.GetComponent<Renderer>().material.color = Color.gray;
            popUpText.GetComponentInChildren<TextMeshPro>().color = Color.red;
            popUpText.GetComponentInChildren<TextMeshPro>().text = response;
            popUpText.GetComponentInChildren<TextMeshPro>().enableAutoSizing = true;
            popUpText.transform.LookAt(popUpText.transform.position - child.transform.position);
            // have it dissapear when clicked? Now it dissapears in textpopup.cs

            Destroy(popUpText, DestroyTime);
        }
        else
        {
            Debug.Log("No pop up text prefab");
        }
    }
}
