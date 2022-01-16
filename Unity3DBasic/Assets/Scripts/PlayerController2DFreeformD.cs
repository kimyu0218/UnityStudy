using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DFreeformD : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");         // ��/�� ����Ű
        float vertical = Input.GetAxis("Vertical");             // ��/�Ʒ� ����Ű

        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;   // (�ȱ�/�ٱ� ����)

        animator.SetFloat("Horizontal", horizontal * offset);
        animator.SetFloat("Vertical", vertical * offset);
    }
}
