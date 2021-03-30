using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomManager : MonoBehaviour
{
    SneakerZoom _sneakerZoom;

    private void Start()
    {
        _sneakerZoom = FindObjectOfType<SneakerZoom>();
    }

    public void Zoomer()
    {
        _sneakerZoom.Zoom();
    }
}
