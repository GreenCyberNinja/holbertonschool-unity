using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public bool isPaused;
    public float speed;
    public float jmpHeight;
    public float fallMul = 2.5f;
    public float midJspd;
    public float Grndspd;
    public GameObject plchar;
    public Vector3 reset;


    bool isGrounded;
    bool mdjmp;
 
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        animator = plchar.GetComponent<Animator>();
    }
    void Update()
    {
        if (rb.transform.position.y < -15)
        {
            rb.transform.position = reset;
            animator.SetBool("Falling", true);
        }
    }
    void FixedUpdate()
    {
        if (!isPaused)
            Move();
    }
    void Move()
    {
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 mvedir = new Vector3(X, 0, Z);
        if (X > 0.0f || X < 0.0f || Z < 0 || Z > 0)
            animator.SetBool("IsMoving", true);
        else
            animator.SetBool("IsMoving", false);
        plchar.transform.rotation = Quaternion.Slerp(plchar.transform.rotation, Quaternion.LookRotation(mvedir), 0.15f);

        rb.MovePosition(transform.position + mvedir * speed);
        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
            mdjmp = true;
            speed = midJspd;
            rb.AddForce(Vector3.up * jmpHeight, ForceMode.Impulse);
            }
        }
        if (!Input.GetButton("Jump"))
        {
            animator.SetBool("IsJumping", false);
            if (mdjmp)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMul -1) * Time.deltaTime;
            }
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
            animator.SetBool("Falling", false);
            mdjmp = false;
            speed = Grndspd;
        }
    }
}
