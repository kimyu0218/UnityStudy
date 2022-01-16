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

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;   // ���콺 Ŀ�� ��ġ ����

        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        playerAnimator.OnMovement(x, z);    // �ִϸ��̼� �Ķ���� ����

        movement3D.MoveSpeed = z > 0 ? 5.0f : 2.0f;
        movement3D.MoveTo(cameraTransform.rotation * new Vector3(x, 0, z));

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        // ���� (�����̽��� ������ �۵�)
        if (Input.GetKeyDown(jumpKeyCode))
        {
            playerAnimator.OnJump();        // �ִϸ��̼� �Ķ���� ����
            movement3D.JumpTo();
        }

        // ���� ���� (���콺 ���� ��ư ������ �۵�)
        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.OnWeaponAttack();
        }
    }
}