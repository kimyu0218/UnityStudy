using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private GameObject attackCollision;

    private void Awake()    // (초기화 함수)
    {
        animator = GetComponent<Animator>();
    }

    // 애니메이션 파라미터
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