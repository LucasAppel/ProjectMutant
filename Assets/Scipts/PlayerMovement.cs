using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 500.0f;
    public float moveThreshold = 0.1f;
    public Animator animator;

   

    private Rigidbody rigidBody;
    public bool isGrounded = true;

    void Start()
    {
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
            }


        if (Input.GetKey ("left shift"))
            {
            speed = 25.0f;
            animator.SetBool("isRunning", true);
             }

        else
        {
            speed = 10.0f;
            animator.SetBool("isRunning", false);
        }

        

        }


        


        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                animator.SetBool("isJumping", false);
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
                animator.SetBool("isJumping", true);
            }
        }
    }