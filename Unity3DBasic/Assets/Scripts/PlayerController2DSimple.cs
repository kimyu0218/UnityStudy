using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DSimple : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");     // ��/�� ����Ű
        float vertical = Input.GetAxis("Vertical");         // ��/�Ʒ� ����Ű

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
