using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timtxt;
    void OnTriggerEnter()
    {
        FindObjectOfType<Timer>().timeStart = false;
        timtxt.color = Color.green;
        timtxt.fontSize = 60;
    }
}
