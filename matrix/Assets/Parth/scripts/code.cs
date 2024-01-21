using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class code : MonoBehaviour
{
    int code_num = 0;
    int final_code = 0;
    public GameObject flashing;


    private void Awake()
    {
        final_code = 100 * spawner.yellow + 10 * spawner.green + spawner.blue;
        Debug.Log(final_code);
    }

    private void Update()
    {
        if(code_num % 1000 == final_code)
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
            StartCoroutine(waitTime());

            Debug.Log(code_num);
        }

        if (code_num > 444)
        {
            code_num = code_num % 100;
        }
    }

    private IEnumerator waitTime()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        flashing.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        flashing.SetActive(false);
    }
}
