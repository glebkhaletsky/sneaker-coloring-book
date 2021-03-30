using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPalette : MonoBehaviour
{
    public Image MainImage;
    public int Index;
    public List<GameObject> IdPalette = new List<GameObject>();
    public GameObject PanelPalette;

    public void OpenPanel()
    {
        if (PanelPalette.active == false)
        {
            PanelPalette.SetActive(true);
        }
        else
        {
            PanelPalette.SetActive(false);
        }
    }
    public void ClosePanel()
    {
        PanelPalette.SetActive(false);
    }


    public void SetImage(Sprite Image)
    {
        MainImage.sprite = Image;
    }

    public void SetPalette(int id)
    {
        Index = id;
        for (int i = 0; i < IdPalette.Count; i++)
        {
            if (i == Index)
            {
                IdPalette[i].SetActive(true);
            }
            else
            {
                IdPalette[i].SetActive(false);
            }
        }
        PanelPalette.SetActive(false);
    }
    


}
