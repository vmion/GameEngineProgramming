using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_7_RayCast : MonoBehaviour
{
    public Transform target;
    Vector3 moveDir;
    float moveSpeed;
    void Start()
    {
        moveDir = Vector3.zero;
        moveSpeed = 2f;
    }
    /*
        [문제해결]
        매개변수로 전달된 위치의 y축상에서 광선을 발사햐여 교차점을 찾는 함수를 제작
        (질문)
        교차점이 없을 경우의 반환값처리는 어떻게 할 것인가?
    */
    public Vector3? GetIntersectPos(Vector3 _origin, int _layerIndex)
    {
        Vector3 originPos = _origin + new Vector3(0, 100f, 0);
        RaycastHit hitInfo;
        int layerMask = 1 << _layerIndex;
        layerMask = ~layerMask;
        if (Physics.Raycast(originPos, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {
            return hitInfo.point;
        }
        return null;
    }
    public Vector3? GetIntersectPos(Vector3 _origin)
    {
        Vector3 originPos = _origin + new Vector3(0, 100f, 0);
        RaycastHit hitInfo;
        if (Physics.Raycast(originPos, Vector3.down, out hitInfo, Mathf.Infinity))
        {
            return hitInfo.point;
        }
        return null;
    }

    void Update()
    {
        
        //Cube에서 Target을 향하는 Raycast함수
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInf;
            Vector3 dir = target.position - transform.position;
            if (Physics.Raycast(transform.position, dir.normalized,
                out hitInf, Mathf.Infinity))
            {
            }            
        }
        Debug.DrawLine(transform.position, target.position, Color.red);
        /*
        //Cube의 머리위에서 아래로 향하는 Raycast함수 작성
        Vector3 origin = transform.position + Vector3.up * 100f;        
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;
        if(Physics.Raycast(origin, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {           
        }      
        Debug.DrawRay(origin, Vector3.down*100, Color.black);

        //높이차이가 있는 게임오브젝트 위에 올라서는 게임 오브젝트
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir.Set(x, 0, y);
        Vector3 gameObjectPos = transform.position;
        gameObjectPos.x += moveDir.normalized.x * Time.deltaTime * moveSpeed;
        gameObjectPos.y = hitInfo.point.y;
        gameObjectPos.z += moveDir.normalized.z * Time.deltaTime * moveSpeed;
        transform.position = gameObjectPos;
        */
        //[문제해결]
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir.Set(x, 0, y);
        //Player레이어를 레이어마스크로 사용하여 광선과 교차된 좌표를 사용
        Vector3? heightPos = GetIntersectPos(transform.position, LayerMask.NameToLayer("Player"));
        //
        Vector3 gameObjectPos = transform.position;
        gameObjectPos.x += moveDir.normalized.x * Time.deltaTime * moveSpeed;
        gameObjectPos.y = heightPos.HasValue ? heightPos.Value.y : transform.position.y;
        gameObjectPos.z += moveDir.normalized.z * Time.deltaTime * moveSpeed;
        transform.position = gameObjectPos;
        Debug.Log(gameObjectPos);
        //삼항연산자
        //조건? 참일경우 리턴 : 거짓일경우 리턴
    }
}
