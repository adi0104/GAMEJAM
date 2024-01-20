using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchenabler : MonoBehaviour
{
    public Light torchLight1,torchLight2;
    public Animator anim;
    void Start()
    {
        torchLight1.enabled = false;
        torchLight2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("TorchOn") && Input.GetKeyDown(KeyCode.T))
        {
            anim.SetBool("TorchOn", true);
            TorchEnabled();
        }
        else if (anim.GetBool("TorchOn") && Input.GetKeyDown(KeyCode.T))
        {
            anim.SetBool("TorchOn", false);
            torchLight1.enabled = false;
            torchLight2.enabled = false;
        }
    }

    void TorchEnabled()
    {
        //float moveCheck = anim.GetFloat("velocity");
        //if (moveCheck > 0.5)
        
            torchLight1.enabled = true;
            torchLight2.enabled = true;
        
        //else
        //{
           // torchLight1.enabled = false;
            //torchLight2.enabled = false;

        //}
    }
}
