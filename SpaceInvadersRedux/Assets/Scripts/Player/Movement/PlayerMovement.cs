using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; //reference to Controller object

    public float speed = 12f;       //speed multiplier for movement
    public float walkspeed = 16f;

    public float gravity = -9.18f;  //gravitational multiplier
    Vector3 velocity;               //a placeholder variable to represent movement

    public Transform groundCheck;       //reference to object that will do checking (empty gameobject)
    public float groundDistance = 0.4f; //radius of check
    public LayerMask groundMask;        //to check for ground only, not other things

    bool isGrounded;
    public float jumpHeight = 3f;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //performs a check whether a radius around Groundcheck's position touches an object of layer groundMask
        if (isGrounded && velocity.y < 0) //if CheckSphere returns true, and our object is still falling by the numbers
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        //Move is inbuilt function of Character Controller

        //Gravity acting on the CharacterController body
        velocity.y += gravity * Time.deltaTime; //vector3 Y component increases with gravity over time
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
