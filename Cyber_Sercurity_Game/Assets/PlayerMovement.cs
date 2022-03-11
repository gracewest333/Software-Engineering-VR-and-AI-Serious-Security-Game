using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 7f;
    public float gravity = -9.81f;
    
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
   
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {   
        //checks that the player is on the ground

        //if the player is not on the ground which means they are falling make the falling speed 2
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0){
            velocity.y=-2f;
        }

        //get the x and z values from the Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //create the vector which will move the player the value of x to the right and the value of z to the left
        Vector3 move= transform.right * x + transform.forward * z;

        //use the vector to move the player at the correct speed and time 
        controller.Move(move * speed * Time.deltaTime );
        
        //make the player fall using the velocity on the y axis, gravity and time
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
//credit to https://youtu.be/_QajrabyTJc and https://youtu.be/HIyxpl-Yahs