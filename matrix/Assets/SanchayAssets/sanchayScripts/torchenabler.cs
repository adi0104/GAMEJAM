using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchenabler : MonoBehaviour
{
    public Light torchLight;
    public Animator anim;
    void Start()
    {
        torchLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float moveCheck = anim.GetFloat("velocity");
        if (moveCheck > 0.5)
        {
            torchLight.enabled = true;
        }
        else 
        {
            torchLight.enabled = false;
        }
    }
}
