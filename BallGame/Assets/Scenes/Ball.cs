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
        // ������Ʈ ��������
        myCollider = GetComponent<SphereCollider>();
        myRigidbody = GetComponent<Rigidbody>();

        Debug.Log("UseGravity?:" + myRigidbody.useGravity);

        Debug.Log("Start");
        //startingPoint = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //myCollider.radius = myCollider.radius + 0.0001f; // �浹 ����
       if (Input.GetKeyDown(KeyCode.Space)) // �����̽� ������ ����
        {
            //Debug.Log("Space�� �������ϴ�.");
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
        }
    }

    void TestMethod()
    {
        Debug.Log("This is TestMethod");
    }
}
