using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private float target_height = 1.8f;
    private float previous_y = 0;
    private bool is_crouching = false;


    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
           
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 6;
            }
            else
            {
                speed = 4;
            }

        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (is_crouching == false)
            {
                is_crouching = true;
                target_height = 1f;
            }
            else
            {
                is_crouching = false;
                target_height = 2f;
            }
        }
        controller.height = Mathf.Lerp(controller.height, target_height, 5f * Time.fixedDeltaTime);


    }

}
