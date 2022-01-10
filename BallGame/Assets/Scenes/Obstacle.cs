using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float delta = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TestMethod("Ball"); // Obstacle부터 Ball까지의 거리

        float newXposition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(newXposition,
            transform.localPosition.y,
            transform.localPosition.z); 

        if (transform.localPosition.x < -3.5)
        {
            delta = 0.1f; // 오른쪽으로 이동
        }
        else if (transform.localPosition.x > 3.5)
        {
            delta = -0.1f; // 왼쪽으로 이동
        }
    }

    void OnCollisionEnter(Collision collision) // (충돌한 상대에 대한 정보)
    {
        //Debug.Log(collision.gameObject.name); // 충돌한 오브젝트 이름 출력
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        direction = direction.normalized * 1000;

        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }

    /*
    void TestMethod(string name)
    {
        float distance = Vector3.Distance(GameObject.Find(name).transform.position, transform.position);
        Debug.Log(name + "까지 거리: " + distance);
    }
    */
}
