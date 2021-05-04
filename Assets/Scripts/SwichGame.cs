using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwichGame : MonoBehaviour
{
    public int Index;
    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void SetSneaker(int id)
    {
        Index = id;
        PlayerPrefs.SetInt("Index", id);
    }
}
