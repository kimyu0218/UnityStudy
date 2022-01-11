using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball") // Ball과 Coin이 충돌하면 Coin을 없앰
        {
            GameObject.Find("GameManager").SendMessage("GetCoin"); // 코인 개수 증가
            Destroy(gameObject);
        }
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
