/*
 * Attach script to Player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player movement variables
    private float speed = 20;
    private float horizontalInput;
    private float verticalInput;
    public CharacterController playerController;

    //player gravity variable
    Vector3 velocity;
    public float gravity = -9.81f;

    //ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f; //radius of sphere using to check
    public LayerMask groundMask; //control what objects sphere should check for
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //call horizontal & vertical inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move horizontal & vertical
        Vector3 move = transform.right * horizontalInput + transform.forward * verticalInput;

        //mouse movement
        playerController.Move(move * speed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
    
}
