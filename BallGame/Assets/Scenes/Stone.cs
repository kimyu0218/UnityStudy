using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Ball").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        transform.Rotate(new Vector3(0, 0, 5));
    }

    void OnTriggerEnter(Collider collider) // (isTrigger 체크 후 사용)
    {
        if (collider.gameObject.name == "Ball") // Ball이 Stone과 부딪히면 게임 재시작
        {
            //GameObject.Find("GameManager").SendMessage("RestartGame");
            GameManager gmComponent = GameObject.Find("GameManager").GetComponent<GameManager>();
            gmComponent.RestartGame();
        }
    }
}
