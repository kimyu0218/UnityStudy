using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkClimb : MonoBehaviour
{
    [SerializeField]
    private int offMeshArea = 3;        // �����޽��� ���� (Climb)
    [SerializeField]
    private float climbSpeed = 1.5f;    // ���������� �̵� �ӵ�

    private NavMeshAgent navMeshAgent;

    private void Awake()    // (�ʱ�ȭ �Լ�)
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
        // ���� ������Ʈ�� ��ġ�� OffMeshLink�� �ִ���
        if (navMeshAgent.isOnOffMeshLink)
        {
            
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            // �������� ������ OffMeshLink && "Climb"
            if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMeshArea)
            {
                return true;
            }
        }

        return false;
    }

    private IEnumerator ClimbOrDescend()
    {
        navMeshAgent.isStopped = true; // �̵� ����

        // ���� ��ġ�� �ִ� OffMeshLink�� ����/���� ��ġ
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
            transform.position = Vector3.Lerp(start, end, percent);     // �÷��̾� �̵�
            yield return null;
        }

        navMeshAgent.CompleteOffMeshLink();
        navMeshAgent.isStopped = false;
    }
}