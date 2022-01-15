using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D_2 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Awake()    // (초기화 함수)
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    public void MoveTo(Vector3 goalPosition)    // 이동 
    {
        StopCoroutine("OnMove");
        // 이동 속도 설정
        navMeshAgent.speed = moveSpeed;
        // 목표 지점 설정
        navMeshAgent.SetDestination(goalPosition);
        // 코루틴 시작
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (true) {
            // 목표 위치에 거의 도달했을때 (0.1 미만)
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination; 
                navMeshAgent.ResetPath();     // 경로 초기화 & 이동 중지
                break;
            }
            yield return null;
        }
    }
}
