using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletTest : MonoBehaviour
{

    [SerializeField] private Button _button;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponentInChildren<Button>();
        _slider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//     OnClick()
//     {
//         Debug.Log("Button clicked");
//     }
}
