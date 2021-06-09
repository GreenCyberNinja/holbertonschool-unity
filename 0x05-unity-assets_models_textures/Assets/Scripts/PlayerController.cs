using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jmpHeight;
    public float fallMul = 2.5f;
    public float midJspd;
    public float Grndspd;

    bool isGrounded;
    bool mdjmp;
 
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (rb.transform.position.y < -15)
        {
            rb.transform.position = new Vector3(0, 25, 0);
        }
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        rb.MovePosition(transform.position + new Vector3(X, 0 ,Z) * speed);
        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
            isGrounded = false;
            mdjmp = true;
            speed = midJspd;
            rb.AddForce(Vector3.up * jmpHeight, ForceMode.Impulse);
            }
        }
        if (!Input.GetButton("Jump"))
        {
            if (mdjmp)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMul -1) * Time.deltaTime;
            }
        }

    }
    void OnCollisionStay()
    {
        isGrounded = true;
        mdjmp = false;
        speed = Grndspd;
    }
}
