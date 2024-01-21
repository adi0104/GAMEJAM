using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool isPaused=false;
    public GameObject pausemenu,settingmenu;
    public CinemachineVirtualCamera fps;
    void Awake()
    {
        changeSensitivity(main_menu.initialSensitivity);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale=1;
        pausemenu.SetActive(false);
        settingmenu.SetActive(false);
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
        settingmenu.SetActive(false);
        pausemenu.SetActive(false);
        isPaused=false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("resume");
    }

    public void settings()
    {
        pausemenu.SetActive(false);
        settingmenu.SetActive(true);
    }

    public void back()
    {
        settingmenu.SetActive(false);
        pausemenu.SetActive(true);
    }

    public void changeVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void changeSensitivity(float sensitivity)
    {
        fps.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = sensitivity;
        fps.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = sensitivity;
    }
    public void quit()
    {
        SceneManager.LoadScene(0);
    }
}
