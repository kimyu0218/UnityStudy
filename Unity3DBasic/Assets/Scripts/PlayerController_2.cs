using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    private Movement3D_2 movement3D;

    private void Awake()    // (초기화 함수)
    {
        movement3D = GetComponent<Movement3D_2>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))     // 마우스 왼쪽 버튼을 눌렀을 때
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // 광선 생성

            // (광선에 부딪히는 오브젝트의 정보를 hit에 저장)
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                movement3D.MoveTo(hit.point);   // hit.point로 이동
            }
        }
    }
}
