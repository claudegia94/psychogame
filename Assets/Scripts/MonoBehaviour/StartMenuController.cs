using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    [SerializeField]
    private string LevelName = "SampleScene";

    public void LoadGame()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadSceneAsync(LevelName);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Scene");
        Application.Quit();
    } 
}
