using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSneaker : MonoBehaviour
{
    public List<GameObject> Sneakers = new List<GameObject>();
    int _index;

    private void Awake()
    {
        _index = PlayerPrefs.GetInt("Index");

        for (int i = 0; i < Sneakers.Count; i++)
        {
            if (i == _index)
            {
                Sneakers[i].SetActive(true);
            }
            else
            {
                Sneakers[i].SetActive(false);
            }
        }
        PlayerPrefs.DeleteKey("Index");
    }
}
