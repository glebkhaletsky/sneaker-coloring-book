using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveImage : MonoBehaviour
{
    public GameObject Interface;
    SneakerZoom _sneakerZoom;

    private void Start()
    {
        _sneakerZoom = FindObjectOfType<SneakerZoom>();
    }

}
