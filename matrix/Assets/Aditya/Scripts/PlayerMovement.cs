using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 12f;
    public float jumpSpeed = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
 
    Vector3 velocity;
 
    bool isGrounded;
 
    // Update is called once per frame
    void Update()
    {
        //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move=new Vector3(x,0,z).normalized;
        //right is the red Axis, foward is the blue axis
        if(move.magnitude>0.1f) 
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg+cam.eulerAngles.y;

            // Calculate movement vector in the rotated direction
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply movement
            transform.position += moveDir * speed * Time.deltaTime;
        }
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,
                                                                jumpSpeed,
                                                                    GetComponent<Rigidbody>().velocity.z);
        }

    }
}

 


    //     // Check if there is any input (non-zero vector)
    //     if (movement.magnitude >= 0.1f)
    //     {
            
    //     }
    // }