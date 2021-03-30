using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
    Vector3 _startScale;
    Paint _paint;
    public Color Color;
    Vector3 _startPosition;
    Collider _colider;
    private void Start()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;
        _paint = FindObjectOfType<Paint>();
        Color = GetComponent<Renderer>().material.color;
        _colider = GetComponent<Collider>();
    }

    public void SetPostion(Vector3 position)
    {
        float distance = Vector3.Distance(_startPosition, position);
        float interpolat = Mathf.InverseLerp(0.3f, 0.7f, distance);
        float scale = Mathf.Lerp(1.1f, 0.25f, interpolat);
        transform.position = position;
        transform.localScale = Vector3.one * scale;
    }

    public void BackToStart()
    {
        transform.position = _startPosition;
        transform.localScale = _startScale;
        _colider.enabled = true;
    }
    private void OnMouseDown()
    {
        _colider.enabled = false;
        _paint.SetSample(this);
    }

    private void OnMouseEnter()
    {
        transform.localScale = _startScale * 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale = _startScale;
    }

}
