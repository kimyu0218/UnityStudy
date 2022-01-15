using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;     // �̵� �ӵ�
    private Vector3 moveDirection;      // �̵� ����

    private float gravity = -9.81f;     // �߷� ���
    [SerializeField]
    private float jumpForce = 3.0f;     // �ٴ� ��

    [SerializeField]
    private Transform cameraTransform;   // ī�޶� Transform ������Ʈ

    private CharacterController characterController;    // (player�� characterController �߰��� ����)

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(characterController.isGrounded == false)     // �߷� ����
        {
            moveDirection.y += gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void MoveTo(Vector3 direction)
    {
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection =  new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    public void JumpTo() // ���� �Լ�
    {
        if(characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }
}
