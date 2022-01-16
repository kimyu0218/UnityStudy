using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;

    private void Awake()    // (초기화 함수) 
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage + "의 체력이 감소합니다.");
        animator.SetTrigger("onHit");
        StartCoroutine("OnHitColor");
    }

    private IEnumerator OnHitColor() // 0.1초간 색상 변경
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material.color = originColor;
    }
}
