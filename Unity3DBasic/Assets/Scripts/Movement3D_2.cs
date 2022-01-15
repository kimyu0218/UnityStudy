using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D_2 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    public void MoveTo(Vector3 goalPosition)    // �̵� 
    {
        StopCoroutine("OnMove");
        // �̵� �ӵ� ����
        navMeshAgent.speed = moveSpeed;
        // ��ǥ ���� ����
        navMeshAgent.SetDestination(goalPosition);
        // �ڷ�ƾ ����
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (true) {
            // ��ǥ ��ġ�� ���� ���������� (0.1 �̸�)
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination; 
                navMeshAgent.ResetPath();     // ��� �ʱ�ȭ & �̵� ����
                break;
            }
            yield return null;
        }
    }
}
