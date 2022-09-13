using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���콺�� ������ ��ǥ�������� �̵��ϴ� ���ӿ�����Ʈ
public class _9_8_MousePickMove : MonoBehaviour
{
    Vector3 end; //���Ӱ������� ��ǥ����
    public float moveSpeed;
    public float rotateSpeed;
        
    void Start()
    {
        //rotateSpeed = 10f;
        //moveSpeed = 2f;
        end = transform.position;       
    }
        
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    end = hitInfo.point;
                }
            }
        }
        transform.position = 
            Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
        //���ӿ�����Ʈ ȸ������
        //���� ����-�������� ���� �ؼ�
        //���̸� �����Ͽ� ȸ���� ����ϱ� ���ؼ� ���콺�� ������
        //���� �������� ��ǥ�� ���̿� ĳ����(���ӿ�����Ʈ)�� ���̸� ����
        Vector3 tmpEnd = end;
        tmpEnd.y = transform.position.y;
        //1. ���⺤��
        //������(��)���� ��ǥ��(end)���� ���ϴ� ���⺤��
        Vector3 dir = tmpEnd - transform.position;
        //2.������ ��ǥ���� ���� ȸ���� ��Ÿ���� ���Ѵ�.
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized
            , Time.deltaTime * rotateSpeed, 0f);
        //3.������� �������ش�. Quaternion��������
        Quaternion rotation = Quaternion.LookRotation(newDir.normalized);
        transform.rotation = rotation;      
        
    }
}
