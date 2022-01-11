using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball"); // (카메라가 Ball 따라다님)
       /*
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        for (int i = 0; i < coins.Length; i++)
        {
            Debug.Log(coins[i].name);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("I am Camera. And ball is at " + ball.transform.position.z);
        transform.position = new Vector3(
            ball.transform.position.x, 
            ball.transform.position.y + 5, 
            ball.transform.position.z - 15);
    }
}
