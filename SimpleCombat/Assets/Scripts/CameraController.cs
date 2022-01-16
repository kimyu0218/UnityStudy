using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;       // 카메라가 추적하는 대상
    [SerializeField]
    private float minDistance = 3;  // 카메라와 target의 최소 거리
    [SerializeField]
    private float maxDistance = 30; // 카메라와 target의 최대 거리
    [SerializeField]
    private float wheelSpeed = 500; // 마우스 휠 스크롤 속도
    [SerializeField]
    private float xMoveSpeed = 500; // 카메라의 y축 회전 속도
    [SerializeField]
    private float yMoveSpeed = 250; // 카메라의 x축 회전 속도
    private float yMinLimit = 5;    // 카메라 x축 회전 제한 최소 값
    private float yMaxLimit = 80;   // 카메라 x축 회전 제한 최대 값
    private float x, y;             // 마우스 이동 방향 값
    private float distance;         // 카메라와 target의 거리

    private void Awake()    // (초기화 함수)
    {
        distance = Vector3.Distance(transform.position, target.position);
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    private void Update()
    {
        if (target == null) return;

        // 오른쪽 마우스를 누르고 있을 때
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
            transform.rotation = Quaternion.Euler(y, x, 0); // 카메라 회전 정보 갱신
        }

        // 카메라와 target 사이 distance 조절
        distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed * Time.deltaTime;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        // 카메라의 위치 갱신 : target에서 distacne만큼 떨어짐
        transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
