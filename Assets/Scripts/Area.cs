using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    Renderer _renderer;
    public Color CurrentColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        CurrentColor = _renderer.material.color;
    }

    public void OnHower(Color color)
    {

        _renderer.material.color = color;
        
    }

    public void OnUnhower()
    {
        _renderer.material.color = CurrentColor;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
        CurrentColor = color;
    }
}
