using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneController : MonoBehaviour
{
    // Update is called once per frame
    public GameObject maincam;
    public GameObject CtScncam;
    public GameObject player;
    public GameObject timer;
    public Animator anim;
    public bool Isplaying;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            Isplaying = true;
        else
            Isplaying = false;

        if (!Isplaying)
        {
            maincam.SetActive(true);
            player.GetComponent<PlayerController>().enabled = true;
            timer.SetActive(true);
            CtScncam.SetActive(false);
        }

    }
}
