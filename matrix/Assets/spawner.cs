using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject[] balls =  new GameObject[3];
    public static int yellow;
    public static int green;
    public static int blue;

    [SerializeField] float forceMagnitude = 5f;

    void Awake()
    {
        System.Random random = new System.Random();

        yellow = random.Next(1, 4);

        green = random.Next(1, 4);

        blue = random.Next(1, 4);

        for (int i = 0; i < yellow; i++)
        {
            GameObject yellowBall = Instantiate(balls[0], transform.position, Quaternion.identity);
            AddForceToBall(yellowBall);
        }

        for (int i = 0; i < green; i++)
        {
            GameObject greenBall = Instantiate(balls[1], transform.position, Quaternion.identity);
            AddForceToBall(greenBall);
        }

        for (int i = 0; i < blue; i++)
        {
            GameObject blueBall = Instantiate(balls[2], transform.position, Quaternion.identity);
            AddForceToBall(blueBall);
        }
    }
    void AddForceToBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {   

    }
}
