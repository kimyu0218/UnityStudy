using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zRotation = transform.localEulerAngles.z;
        zRotation = zRotation + Input.GetAxis("Horizontal"); // 화살표 입력
        transform.localEulerAngles = new Vector3(10, 0, zRotation);

        if(Input.touchCount > 0 || Input.GetMouseButton(0)) // 왼쪽 버튼이 눌린 경우
        {
            //Debug.Log("mouse Down: " + Input.mousePosition); // 터치 위치값
            if(Input.mousePosition.x < Screen.width / 2) // 왼쪽 화면 클릭
            {
                transform.localEulerAngles = new Vector3(10, 
                    0, 
                    transform.localEulerAngles.z + 1.0f);
            }
            else // 오른쪽 화면 클릭
            {
                transform.localEulerAngles = new Vector3(10,
                    0,
                    transform.localEulerAngles.z - 1.0f);
            }
        }
    }
}
