using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public Sample CurrentSample;
    public Camera Camera;
    public Area CurrentArea;
    void Start()
    {
        
    }

    void Update()
    {
        if (CurrentSample == null)
        {
            return;
        }
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5f);

        Vector3 point = ray.GetPoint(1f);
        CurrentSample.SetPostion(point);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Area area = hit.collider.gameObject.GetComponent<Area>();
            Debug.Log(hit.collider.gameObject.name);
            if (area)
            {
                if(area != CurrentArea)
                {
                    if (CurrentArea)
                    {
                        CurrentArea.OnUnhower();
                    }
                }
                
                CurrentArea = area;
                CurrentArea.OnHower(CurrentSample.Color);

                if (Input.GetMouseButtonUp(0))
                {
                    CurrentArea.SetColor(CurrentSample.Color);
                }
            }
        }
        else
        {
            if (CurrentArea)
            {
                CurrentArea.OnUnhower();
                CurrentArea = null;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            CurrentSample.BackToStart();
            CurrentSample = null;
            
        }
       
    }

    public void SetSample(Sample sample)
    {
        CurrentSample = sample;
    }
}
