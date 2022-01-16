using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    private Movement3D movement3D;

    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    private PlayerAnimator playerAnimator;

    private void Awake()    // (초기화 함수)
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서 위치 고정

        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        playerAnimator.OnMovement(x, z);    // 애니메이션 파라미터 설정

        movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        // 점프 (스페이스바 누르면 작동)
        if (Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump();        // 애니메이션 파라미터 설정
            movement3D.JumpTo();
        }

        // 무기 공격 (마우스 왼쪽 버튼 누르면 작동)
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.OnWeaponAttack();
        }
    }
}