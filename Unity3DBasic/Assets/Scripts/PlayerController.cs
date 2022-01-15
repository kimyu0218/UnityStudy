using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;
    [SerializeField]
    private CameraController cameraController;

    private void Awake()    // (초기화 함수)
    {
        movement3D = GetComponent<Movement3D>();
    }

    private void Update()
    {
        // x, z 방향 이동
        float x = Input.GetAxisRaw("Horizontal");   // 방향키 좌/우 움직임
        float z = Input.GetAxisRaw("Vertical");     // 방향키 위/아래 움직임

        movement3D.MoveTo(new Vector3(x, 0, z));

        // 점프 (스페이스바 누르면 작동)
        if(Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        float mouseX = Input.GetAxis("Mouse X");    // 마우스 좌/우 움직임
        float mouseY = Input.GetAxis("Mouse Y");    // 마우스 위/아래 움직임

        cameraController.RotateTo(mouseX, mouseY);
    }
}
