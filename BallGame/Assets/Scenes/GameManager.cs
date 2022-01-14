using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText;

    public void RestartGame() // ���� �����
    {
        Application.LoadLevel("Game");
    }

    void RedCoinStart() // ���� ���� �۵�
    {
        DestroyObstacles();
    }

    void DestroyObstacles() // ���ع� ����
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

    }

    void GetCoin() // ���� ���� ����
    {
        coinCount++;
        coinText.text = coinCount + "��";
        Debug.Log("����: " + coinCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coinCount + "��";
    }

    // Update is called once per frame
    void Update()
    {

    }

}
