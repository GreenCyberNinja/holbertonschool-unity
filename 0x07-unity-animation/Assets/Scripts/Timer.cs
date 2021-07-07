using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    float timer = 0.00f;
    public bool timeStart = false;
    void Update()
    {
        if (timeStart == true)
        {
            timer += Time.deltaTime;
            text.text = timer.ToString("0:00.00");
        }
    }
}
