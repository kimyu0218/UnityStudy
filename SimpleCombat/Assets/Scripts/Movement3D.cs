using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     // 이동 속도
    private Vector3 moveDirection;      // 이동 방향

    private float gravity = -9.81f;     // 중력 계수
    [SerializeField]
    private float jumpForce = 3.0f;     // 뛰는 힘

    private CharacterController characterController;

    private void Awake()    // (초기화 함수)
    {
        characterController = GetComponent<CharacterController>();
    }

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Clamp(value, 2.0f, 5.0f);  // (이동 속도 : 2 ~ 5)
    }

    private void Update()
    {
        if (characterController.isGrounded == false)     // 중력 적용
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }

    public void JumpTo() // 점프 함수
    {
        if (characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}