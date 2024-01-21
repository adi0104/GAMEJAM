using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class dialogue : MonoBehaviour
{
    public TMP_Text textBox;
    public string[] sentences;
    public int size=5;
    int currentIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentIndex<size) Time.timeScale=0;
        if(Input.GetKeyDown(KeyCode.E) && currentIndex<size)
        {
            textBox.text=sentences[currentIndex++];
            if(currentIndex==size) 
            {
                textBox.text="";
                Time.timeScale=1;
            }
        }
    }
}
