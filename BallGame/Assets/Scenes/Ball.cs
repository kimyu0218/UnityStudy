using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //float startingPoint;

    Rigidbody myRigidbody;
    SphereCollider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 가져오기
        myCollider = GetComponent<SphereCollider>();
        myRigidbody = GetComponent<Rigidbody>();

        Debug.Log("UseGravity?:" + myRigidbody.useGravity);

        Debug.Log("Start");
        //startingPoint = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //myCollider.radius = myCollider.radius + 0.0001f; // 충돌 범위
       if (Input.GetKeyDown(KeyCode.Space)) // 스페이스 누르면 점프
        {
            //Debug.Log("Space를 눌렀습니다.");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }
    }

    void TestMethod()
    {
        Debug.Log("This is TestMethod");
    }
}
