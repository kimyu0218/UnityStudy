using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider collider) // (isTrigger 체크 후 사용)
    {
        if(collider.gameObject.name == "Ball") // Ball이 FailZone으로 떨어지면 게임 재시작
        {
            Application.LoadLevel("Game");
        }
    }
}
