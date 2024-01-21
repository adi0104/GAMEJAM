using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class win: MonoBehaviour
{

    public GameObject mainmenu;

    // Start is called before the first frame update 
    void Awake()
    {
        mainmenu.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }



    public void home()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
