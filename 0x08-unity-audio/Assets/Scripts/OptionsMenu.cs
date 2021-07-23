using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class OptionsMenu : MonoBehaviour
{
    public Toggle yinvT;

    public void Start ()
    {
            yinvT.isOn = System.Convert.ToBoolean(PlayerPrefs.GetString("yinvert"));
    }
    public void Back()
    {
        string Ls = PlayerPrefs.GetString("lastScene");
        SceneManager.LoadScene($"{Ls}");
    }
    public void Apply ()
    {
        if (yinvT.isOn.ToString() != PlayerPrefs.GetString("yinvert"))
        {
            PlayerPrefs.SetString("yinvert", yinvT.isOn.ToString());
        }
        string Ls = PlayerPrefs.GetString("lastScene");
        SceneManager.LoadScene($"{Ls}");
    }
}
