using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1D : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");     // ��/�Ʒ� ����Ű

        // (shift ������ �ִ� 1.0)
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        float moveParameter = Mathf.Abs(vertical * offset);

        // 0 : ��� | 0.5 : �ȱ� | 1.0 �ٱ�
        animator.SetFloat("moveSpeed", moveParameter); 
    }
}
