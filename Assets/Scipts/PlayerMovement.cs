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

        if (movement.y > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else if (movement.y < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }


        if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Mathf.Abs(movement.y) > 0)
            {
                animator.SetBool("isRunning", true);
                transform.position += new Vector3(movement.y * speed * Time.deltaTime, 0, 0);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Debug.Log("Jump pressed");
                rigidBody.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
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