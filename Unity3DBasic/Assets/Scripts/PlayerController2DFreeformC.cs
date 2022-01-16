using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DFreeformC : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (초기화 함수)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
