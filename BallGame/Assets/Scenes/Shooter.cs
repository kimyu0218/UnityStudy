using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Obstacle
{
    float timeCount = 0;
    public GameObject stone;

    // Update is called once per frame
    void Update()
    {
        base.Update(); // �θ� Ŭ���� �Լ� ����

        // Shooter ���� ���
        timeCount += Time.deltaTime;
        if(timeCount > 3)
        {
            //Debug.Log("���� ������");
            Instantiate(stone, transform.position, Quaternion.identity); // ���� ����
            timeCount = 0;
        }

    }
}