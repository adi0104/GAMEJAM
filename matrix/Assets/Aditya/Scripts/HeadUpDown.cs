using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadUpDown : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float xrot_lower_limit=-90f;
    public float xrot_upper_limit=90f;
    float xRotation = 0f;
 
    void Start()
    {
      //Locking the cursor to the middle of the screen and making it invisible
      Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
       //control rotation around x axis (Look up and down)
       xRotation -= mouseY;
 
       //we clamp the rotation so we cant Over-rotate (like in real life)
       xRotation = Mathf.Clamp(xRotation, xrot_lower_limit,xrot_upper_limit);
 
       //applying both rotations
       transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
 
    }
}
