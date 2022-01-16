using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1D : MonoBehaviour
{
    private Animator animator;

    private void Awake()    // (초기화 함수)
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");     // 위/아래 방향키

        // (shift 누르면 최대 1.0)
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;

        float moveParameter = Mathf.Abs(vertical * offset);

        // 0 : 대기 | 0.5 : 걷기 | 1.0 뛰기
        animator.SetFloat("moveSpeed", moveParameter); 
    }
}
