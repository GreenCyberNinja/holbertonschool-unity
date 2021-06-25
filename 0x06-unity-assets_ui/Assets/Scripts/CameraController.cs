using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float smoSpd;
    public float rotSpd;
    public bool isInverted;
    float vert;
    float hor;

    void Start ()
    {
        isInverted = System.Convert.ToBoolean(PlayerPrefs.GetString("yinvert"));
    }
    void LateUpdate()
    {
        vert = Input.GetAxis("Mouse Y");
        hor = Input.GetAxis("Mouse X");
        if (isInverted)
        {
            vert = -vert;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Quaternion camTurnangle = Quaternion.Euler(vert * rotSpd, hor * rotSpd, 0);
            offset = camTurnangle * offset;
        }
        Vector3 posDes = player.transform.position + offset;
        Vector3 smoPos = Vector3.Lerp(transform.position, posDes, smoSpd);
        transform.position = smoPos;
        transform.LookAt(player.transform);
    }
}