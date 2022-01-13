using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) // (isTrigger üũ �� ���)
    {
        if (collider.gameObject.name == "Ball") // Ball�� FailZone���� �������� ���� �����
        {
            //GameObject.Find("GameManager").SendMessage("RestartGame");
            GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
            gmComponent.RestartGame();
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
