using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float walkSpeed = 6.0f;
    private float speed;
    public float runSpeed = 20.0f;
    public float jumpForce = 500.0f;
    public float moveThreshold = 0.1f;
    public Animator animator;

   

    private Rigidbody rigidBody;
    public bool isGrounded = true;

    void Start()
    {
        speed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);



        if (moveVertical > 0)
        {
            animator.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


        if (moveVertical < 0)
        {
            animator.SetBool("isWalking", true);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (moveVertical == 0)

        {
            animator.SetBool("isWalking", false);
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rigidBody.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                animator.SetBool("isJumping", true);
        }


        if (Input.GetKey ("left shift"))
            {
            speed = runSpeed;
            animator.SetBool("isRunning", true);
             }

        else
        {
            speed = walkSpeed;
            animator.SetBool("isRunning", false);
        }

        

        }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }


    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                animator.SetBool("isJumping", false);
            }
        }


    }