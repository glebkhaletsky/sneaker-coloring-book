using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    SneakerZoom _sneaker;
    string _nameSneaker;
    public GameObject UI;

    private void Start()
    {
        _sneaker = FindObjectOfType<SneakerZoom>();
        _nameSneaker = _sneaker.name;
    }
    IEnumerator TakeAndSaveScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();

        byte[] imageBytes = screenImage.EncodeToPNG();
        NativeGallery.SaveImageToGallery(imageBytes, "Sneaker Coloring Book", _nameSneaker +".png", null);
    }

    public void ScreenShot()
    {
        StartCoroutine(TakeAndSaveScreenshot());
    }
}
