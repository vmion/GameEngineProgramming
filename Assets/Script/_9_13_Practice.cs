using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_13_Practice : MonoBehaviour
{
    Vector3 end;
    Transform target;
    float moveSpeed;
    float rotateSpeed;
    void Start()
    {
        moveSpeed = 4f;
        rotateSpeed = 4f;
        end = transform.position;
        target = null;
    }
    void Update()
    {
        //���͸� ���ý� ���� ��ó�� �̵�(���ݰŸ� ��ŭ)
        //���ݰŸ��� 1.5f�̴�.


        //�ٴ��� ���ý� �������� �̵�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            //int layerMask = 1 << LayerMask.NameToLayer("Player");
            //layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Terrain"))
                {
                    end = hitInfo.point;
                    target = null;
                }
                else if(hitInfo.collider.CompareTag("Monster"))
                {
                    target = hitInfo.collider.transform;
                    end = hitInfo.collider.transform.position;
                }
            }
            //���Ϳ��� �Ÿ����
            if (target != null)
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if(distance <= 1.5f)
                {
                    end = transform.position;
                }
            }

            transform.position =
              Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
            //ȸ�����
            Vector3 tmpEnd = end;
            tmpEnd.y = transform.position.y;
            Vector3 dir = tmpEnd - transform.position;
            Vector3 newDir =
               Vector3.RotateTowards(transform.forward, dir.normalized, Time.deltaTime * rotateSpeed, 0);
            Quaternion rotation = Quaternion.LookRotation(newDir.normalized);
            transform.rotation = rotation;

                   
        }
    }
}
