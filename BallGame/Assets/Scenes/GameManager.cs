using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void RestartGame() // 게임 재시작
    {
        Application.LoadLevel("Game");
    }

    void RedCoinStart() // 레드 코인 작동
    {
        DestroyObstacles();
    }

    void DestroyObstacles() // 장해물 제거
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

    }

    int coinCount = 0;
    void GetCoin() // 코인 개수 세기
    {
        coinCount++;
        Debug.Log("동전: " + coinCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
