using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSneaker : MonoBehaviour
{
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    Vector3 _startScale;
    Vector3 _zoomScale;
    Vector3 _startPosition;

    Transform target;
    Collider Collider;
    private Vector3 offset;
    private float distance;
    public bool _drag;
    float _y;


    private void Start()
    {
        Collider = GetComponent<Collider>();
        target = gameObject.transform;
        _startScale = transform.localScale;
        _startPosition = transform.position;
        _zoomScale = transform.localScale * 1.5f;
        _y = transform.position.y;
    }
    bool DoubleClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            return true;
        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        return false;
    }
    private void Update()
    {
        if (DoubleClick())
        {
            if (transform.localScale.y >= 0.6f)
            {
                _drag = false;
            }
            else
            {
                _drag = true;
            }
        }
        if (Input.GetMouseButtonDown(0) && _drag == true)
        {
            Collider.enabled = true;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && ray.origin.x<=0.8f)
            {
                target = hit.transform;
                offset = target.position - hit.point;
                distance = hit.distance;
            }
            if (ray.origin.x > 0.8f)
            {
                Collider.enabled = false;
            }
            else
            {
                Collider.enabled = true;
            }
        }
        if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && target != null && _drag==true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            target.position = ray.origin + ray.direction * distance + offset;
            if (target.position.x <= -1.2)
            {
                target.transform.position = new Vector3(-1.2f, transform.position.y, transform.position.z);
            }
            if (target.position.y >= 0)
            {
                target.transform.position = new Vector3(transform.position.x, _y, transform.position.z);
            }
            if (target.position.x >= 0.5)
            {
                target.transform.position = new Vector3(0.5f, transform.position.y, transform.position.z);
            }
            if (target.position.y <= 0)
            {
                target.transform.position = new Vector3(transform.position.x,_y, transform.position.z);
            }
        }
        if (Input.GetMouseButtonUp(0)|| _drag==false)
        {
            target = null;
            Collider.enabled = false;
        }
        if (_drag == false)
        {
            transform.position = Vector3.Lerp(transform.position, _startPosition, 20f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, _startScale, 20f * Time.deltaTime);
        }
        if (_drag == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _zoomScale , 10f * Time.deltaTime);
        }


    }
}
