using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene($"Level0{level}");
    }
    public void Options()
    {
        PlayerPrefs.SetString("lastScene", "MainMenu");
        SceneManager.LoadScene("Options");
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
