using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class main_menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject mainmenu,settingmenu;
    public static float initialSensitivity=300f;
    // Start is called before the first frame update 
    void Awake()
    {
        mainmenu.SetActive(true);
        settingmenu.SetActive(false);
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

    public void settings()
    {
        settingmenu.SetActive(true);
        mainmenu.SetActive(false);
    }

    public void back()
    {
        settingmenu.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void changeVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void changeSensitivity(float sensitivity)
    {
        initialSensitivity=sensitivity;
    }

    public void home(){
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
