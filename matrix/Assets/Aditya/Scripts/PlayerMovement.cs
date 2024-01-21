using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;
    public float speed = 12f;
    public float JumpForce = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Animator anim;
    public float animSpeed = 0, rotSpeed;
    public Rigidbody rb;

    Vector3 velocity;
 
    bool isGrounded;

    public void Teleport(Vector3 position)
    {
        transform.position = position;
        Physics.SyncTransforms();
        velocity = Vector3.zero;
    }
 
    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("velocity", animSpeed);
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
            if (animSpeed <= 1f)
            { animSpeed += Time.deltaTime * 2f; }
            
            transform.position += moveDir * speed * Time.deltaTime;
        }
        else
        {   
            if (animSpeed>=0)
            animSpeed-= Time.deltaTime*2f;
        }
 
        //check if the player is on the ground so he can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //the equation for jumping
            /*GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x,
                                                                jumpSpeed,
                                                                    GetComponent<Rigidbody>().velocity.z);*/
            rb.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);

        }
        Vector3 forwardDirn = cam.transform.forward;
        forwardDirn.y= 0f;
        Quaternion targetRotation = Quaternion.LookRotation(forwardDirn);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed*Time.deltaTime);

    }
}


 