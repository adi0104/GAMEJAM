using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class code : MonoBehaviour
{
    int code_num = 0;
    int final_code = 0;

    System.Random rand = new System.Random();

    private void Awake()
    {
        for(int i = 0; i < 3; i++)
        {
            final_code = 10 * final_code + rand.Next(1,6);
        }

        Debug.Log(final_code);
    }

    private void Update()
    {
        if(code_num == final_code)
        {
            Debug.Log("FINISH");
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == 3)
        {
            string[] tagparts = collider.gameObject.name.Split('_');
            if(int.TryParse(tagparts[1], out int multiplier))
            {
                code_num = 10 * code_num + multiplier;
            }

            Debug.Log(code_num);
        }

        if (code_num > 666)
        {
            code_num = code_num % 100;
        }
    }
}
