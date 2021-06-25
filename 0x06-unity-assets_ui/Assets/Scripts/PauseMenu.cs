using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject Pmen;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume ()
    {
        gamePause = false;
        FindObjectOfType<Timer>().timeStart = true;
        FindObjectOfType<PlayerController>().isPaused = false;
        Pmen.GetComponent<Canvas>().enabled = (false);
    }
    void Pause ()
    {
        gamePause = true;
        FindObjectOfType<Timer>().timeStart = false;
        FindObjectOfType<PlayerController>().isPaused = true;
        Pmen.GetComponent<Canvas>().enabled = (true);
    }
    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu ()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Options ()
    {
        PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }
}
