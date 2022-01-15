using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_2 : MonoBehaviour
{
    private Movement3D_2 movement3D;

    private void Awake()    // (�ʱ�ȭ �Լ�)
    {
        movement3D = GetComponent<Movement3D_2>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))     // ���콺 ���� ��ư�� ������ ��
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    // ���� ����

            // (������ �ε����� ������Ʈ�� ������ hit�� ����)
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                movement3D.MoveTo(hit.point);   // hit.point�� �̵�
            }
        }
    }
}
