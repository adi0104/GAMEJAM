using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scream : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject player;
    public GameObject jumpZom;
    public GameObject flashing;
    public Animator anim;
    int waitTime;

    void Start()
    {
        System.Random rand = new System.Random();

        waitTime = rand.Next(10, 15);

        StartCoroutine(jumpScare());
    }

    private void Update()
    {
        jumpZom.transform.position = new Vector3(player.transform.position.x + 3f, player.transform.position.y-1f, player.transform.position.z + 3f);
    }
    private void OnTriggerEnter()
    {
        StartCoroutine(jumpScare());
    }

    IEnumerator jumpScare()
    {
        yield return new WaitForSeconds(waitTime);
        Scream.Play();
        jumpZom.SetActive(true);
        flashing.SetActive(true);
        anim.Play("Zombie Scream");
        yield return new WaitForSeconds(2.0f);
        jumpZom.SetActive(false);
        flashing.SetActive(false);
    }

}
