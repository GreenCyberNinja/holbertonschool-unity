using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timtxt;
    public Text Fintxt;
    public Canvas Wcan;
    void OnTriggerEnter()
    {
        FindObjectOfType<Timer>().timeStart = false;
        Wcan.enabled = true;
        Fintxt.text = timtxt.text;
        timtxt.enabled = false;

    }
}
