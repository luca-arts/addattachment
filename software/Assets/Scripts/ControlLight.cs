using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLight : MonoBehaviour
{
    [SerializeField] private Light _light;

    [SerializeField] private Color _originalColor = new Color32(0x04, 0xFF, 0xAC, 0xFF);
    [SerializeField] private Color _targetColor = Color.red;
    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
    public float animationTime = 0.1f;
    public Color highlightColor = Color.red;


    private void Start()
    {
        _light = GetComponentInChildren<Light>();
    }

    private void Update()
    {

        _light.color = Color.Lerp(_light.color, _targetColor, Time.deltaTime * (1 / animationTime));

    }

    public void SetNormalLight()
    {
        _targetColor = _originalColor;
    }

    public void SetHighlight()
    {
        _targetColor = highlightColor;
    }
}
