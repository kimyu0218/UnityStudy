using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText;

    public void RestartGame() // 게임 재시작
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

    void GetCoin() // 코인 개수 세기
    {
        coinCount++;
        coinText.text = coinCount + "개";
        Debug.Log("동전: " + coinCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coinCount + "개";
    }

    // Update is called once per frame
    void Update()
    {

    }

}
