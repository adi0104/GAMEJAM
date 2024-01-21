using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static bool alive=true;
    public static int currentHealth;
    public int maxHealth=10;
    public float regenerationTime=30f;
    float time=0f;
    void Awake()
    {
        currentHealth=maxHealth;
        alive=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<maxHealth)
        {
            time+=Time.deltaTime;
            if(time>=regenerationTime) 
            {
                currentHealth++;
                Debug.Log(Health.currentHealth);
                time=0f;
            }
        }
        if(currentHealth<=0) 
        {
            //alive=false;
            SceneManager.LoadScene(5);
        }
    }
}
