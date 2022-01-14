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
        base.Update(); // 부모 클래스 함수 실행

        // Shooter 고유 기능
        timeCount += Time.deltaTime;
        if(timeCount > 3)
        {
            //Debug.Log("돌을 던져라");
            Instantiate(stone, transform.position, Quaternion.identity); // 스톤 생성
            timeCount = 0;
        }

    }
}