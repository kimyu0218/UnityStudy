using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Animation : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            //animator.Play("Idle");
            animator.SetFloat("moveSpeed", 0.0f);   // (�ִϸ��̼� �Ķ����)
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //animator.Play("RUN00_F");
            animator.SetFloat("moveSpeed", 5.0f);   // (�ִϸ��̼� �Ķ����)
        }
    }
}
