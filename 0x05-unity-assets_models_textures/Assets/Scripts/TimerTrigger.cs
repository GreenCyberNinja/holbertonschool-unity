using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{

    void OnTriggerExit()
    {
        if (FindObjectOfType<Timer>().timeStart == false)
            FindObjectOfType<Timer>().timeStart = true;
    }
}
