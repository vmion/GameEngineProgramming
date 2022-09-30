using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_Test_Player : MonoBehaviour
{
    Vector3 end; 
    float moveSpeed;
    float rotateSpeed;
    
    void Start()
    {       
        end = transform.position;
        moveSpeed = 2f;
        rotateSpeed = 5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Monster"))
                {
                    end = hitInfo.collider.transform.position;                    
                    Debug.Log("몬스터 선택");
                }
                else if (hitInfo.collider.CompareTag("Terrain"))
                {
                    Debug.Log("마우스로 선택한 위치 = " + hitInfo.point);
                    end = hitInfo.point;                    
                }
                else if (hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("캐릭터이름은 'Player' 입니다.");                    
                }
            }
        }
        transform.position =
            Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
        
        Vector3 tmpEnd = end;
        tmpEnd.y = transform.position.y;        
        Vector3 dir = tmpEnd - transform.position;       
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized
            , Time.deltaTime * rotateSpeed, 0f);        
        Quaternion rotation = Quaternion.LookRotation(newDir.normalized);
        transform.rotation = rotation;
    }
}
