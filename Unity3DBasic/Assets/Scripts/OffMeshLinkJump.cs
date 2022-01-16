using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkJump : MonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 10.0f;    // 점프 속도
    [SerializeField]
    private float gravity = -9.81f;     // 중력 계수

    private NavMeshAgent navMeshAgent;

    private void Awake()    // (초기화 함수)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsOnJump());
            yield return StartCoroutine(JumpTo());
        }
    }

    public bool IsOnJump()
    {
        if (navMeshAgent.isOnOffMeshLink)
        {
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            if (linkData.linkType == OffMeshLinkType.LinkTypeJumpAcross ||
                 linkData.linkType == OffMeshLinkType.LinkTypeDropDown)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator JumpTo()
    {
        navMeshAgent.isStopped = true;  // 이동 중지 

        // 현재 위치에 있는 OffMeshLink의 시작/종료 위치
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = transform.position;
        Vector3 end = linkData.endPos;

        float jumpTime = Mathf.Max(0.3f, Vector3.Distance(start, end) / jumpSpeed);
        float currentTime = 0.0f;
        float percent = 0.0f;
        float v0 = (end - start).y - gravity;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / jumpTime;
            
            // 포물선 운동
            Vector3 position = Vector3.Lerp(start, end, percent);
            position.y = start.y + (v0 * percent) + (gravity * percent * percent);
            transform.position = position;  // 플레이어 이동

            yield return null;
        }

        navMeshAgent.CompleteOffMeshLink();
        navMeshAgent.isStopped = false;
    }
}