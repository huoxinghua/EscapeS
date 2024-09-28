using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string SceneName;
    public void LoadScene(string name)
    {
        {
            SceneName = name;
           SceneManager.LoadScene(name);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
