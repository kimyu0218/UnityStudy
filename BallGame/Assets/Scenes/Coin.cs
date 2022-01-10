using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Ball") // Ball과 Coin이 충돌하면 Coin을 없앰
        {
            Destroy(gameObject);
        }
    }
}
