using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    bool isPaused=false;
    public GameObject  pausemenu;
    void Awake()
    {
        Time.timeScale=1;
        pausemenu.SetActive(false);
        isPaused=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            pausescreen();
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            resume();
        }
    }

    public void pausescreen()
    {
        Time.timeScale=0;
        pausemenu.SetActive(true);
        isPaused=true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void resume()
    {
        Time.timeScale=1;
        pausemenu.SetActive(false);
        isPaused=false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void settings()
    {

    }

    public void quit()
    {

    }
}
