using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private GameObject attackCollision;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        animator = GetComponent<Animator>();
    }

    // �ִϸ��̼� �Ķ����
    public void OnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }

    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }

    public void OnWeaponAttack()
    {
        animator.SetTrigger("onWeaponAttack");
    }

    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }
}