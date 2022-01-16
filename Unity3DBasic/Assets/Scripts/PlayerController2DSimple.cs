using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DSimple : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (초기화 함수)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");     // 좌/우 방향키
        float vertical = Input.GetAxis("Vertical");         // 위/아래 방향키

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
