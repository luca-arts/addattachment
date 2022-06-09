using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.G2OM;

public class VREyeTest : MonoBehaviour, IGazeFocusable
{
    private Material _material;
    private Renderer _renderer;

    private Color _originalColor;
    private Color _targetColor;
    private static readonly int _baseColor = Shader.PropertyToID("_BaseColor");
    public float animationTime = 0.1f;
    public Color highlightColor = Color.red;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        //This lerp will fade the color of the object
        if (_renderer.material.HasProperty(_baseColor)) // new rendering pipeline (lightweight, hd, universal...)
        {
            _renderer.material.SetColor(_baseColor, Color.Lerp(_renderer.material.GetColor(_baseColor), _targetColor, Time.deltaTime * (1 / animationTime)));
        }
        else // old standard rendering pipline
        {
            _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, Time.deltaTime * (1 / animationTime));
        }
    }

    public void GazeFocusChanged(bool hasFocus)
    {
        //If this object received focus, fade the object's color to highlight color
        if (hasFocus)
        {
            _targetColor = highlightColor;
        }
        //If this object lost focus, fade the object's color to it's original color
        else
        {
            _targetColor = _originalColor;
        }
    }
}
