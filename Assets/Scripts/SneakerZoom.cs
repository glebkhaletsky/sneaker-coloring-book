using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneakerZoom : MonoBehaviour
{
    Vector3 _startPosition;
    Vector3 _startScale;
    ScaleSneaker _scaleSneaker;
    bool _check;
    Vector3 _zoomScale,_zoomPosition;

    private void Start()
    {
        _scaleSneaker = GetComponent<ScaleSneaker>();
        _startPosition = transform.position;
        _startScale = transform.localScale;
        _zoomScale = new Vector3(0.8f, 0.8f, 0.8f);
        _zoomPosition = new Vector3(0.5f, transform.position.y, transform.position.z);
    }
    public void Zoom()
    {
        _check = !_check;
        if (_check)
        {
            _scaleSneaker.enabled = false;
        }
        if (!_check)
        {
            _scaleSneaker.enabled = true;
            _scaleSneaker._drag = false;
        }
    }

    private void Update()
    {
        if (_check == true)
        {
            
            transform.position = Vector3.Lerp(transform.position, _startPosition,0.1f);
            transform.localScale = Vector3.Lerp(transform.localScale, _startScale, 0.1f);
            transform.localScale = Vector3.Lerp(transform.localScale, _zoomScale, 0.1f);
            transform.position = Vector3.Lerp(transform.position, _zoomPosition, 0.1f);
        }
        else
        {
            if (_scaleSneaker._drag == false)
            {
                transform.position = Vector3.Lerp(transform.position, _startPosition, 0.1f);
                transform.localScale = Vector3.Lerp(transform.localScale, _startScale, 0.1f);
            }
            
        }
        
    }

}
