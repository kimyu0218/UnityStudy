using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkClimb : MonoBehaviour
{
    [SerializeField]
    private int offMeshArea = 3;        // 오프메시의 구역 (Climb)
    [SerializeField]
    private float climbSpeed = 1.5f;    // 오르내리는 이동 속도

    private NavMeshAgent navMeshAgent;

    private void Awake()    // (초기화 함수)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsOnClimb());
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        // 현재 오브젝트의 위치가 OffMeshLink에 있는지
        if (navMeshAgent.isOnOffMeshLink)
        {
            
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            // 수동으로 생성한 OffMeshLink && "Climb"
            if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMeshArea)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator ClimbOrDescend()
    {
        navMeshAgent.isStopped = true; // 이동 중지

        // 현재 위치에 있는 OffMeshLink의 시작/종료 위치
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = linkData.startPos;
        Vector3 end = linkData.endPos;

        float climbTime = Mathf.Abs(end.y - start.y) / climbSpeed;
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / climbTime;
            transform.position = Vector3.Lerp(start, end, percent);     // 플레이어 이동
            yield return null;
        }

        navMeshAgent.CompleteOffMeshLink();
        navMeshAgent.isStopped = false;
    }
}