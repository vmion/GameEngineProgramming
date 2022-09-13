using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//마우스로 선택한 목표지점으로 이동하는 게임오브젝트
public class _9_8_MousePickMove : MonoBehaviour
{
    Vector3 end; //게임공간상의 목표지점
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
        //게임오브젝트 회전적용
        //높이 맞춤-기울어지는 현상 해소
        //높이를 같게하여 회전을 계산하기 위해서 마우스로 선택한
        //게임 공간상의 좌표의 높이에 캐릭터(게임오브젝트)의 높이를 대입
        Vector3 tmpEnd = end;
        tmpEnd.y = transform.position.y;
        //1. 방향벡터
        //시작점(나)에서 목표점(end)으로 향하는 방향벡터
        Vector3 dir = tmpEnd - transform.position;
        //2.전방을 목표점을 향해 회전할 델타량을 구한다.
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized
            , Time.deltaTime * rotateSpeed, 0f);
        //3.계산결과를 리턴해준다. Quaternion형식으로
        Quaternion rotation = Quaternion.LookRotation(newDir.normalized);
        transform.rotation = rotation;      
        
    }
}
