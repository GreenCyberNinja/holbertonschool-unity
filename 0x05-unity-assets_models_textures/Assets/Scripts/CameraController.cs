using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float smoSpd;
    public float rotSpd;
    public bool rotPlayer;
    void LateUpdate()
    {
        if (rotPlayer && Input.GetKey(KeyCode.Mouse1))
        {
            Quaternion camTurnangle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotSpd, Vector3.up);
            offset = camTurnangle * offset;
        }
        Vector3 posDes = player.transform.position + offset;
        Vector3 smoPos = Vector3.Lerp(transform.position, posDes, smoSpd);
        transform.position = smoPos;
        if (rotPlayer)
            transform.LookAt(player.transform);
    }
}