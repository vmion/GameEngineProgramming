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
        [�����ذ�]
        �Ű������� ���޵� ��ġ�� y��󿡼� ������ �߻��Ῡ �������� ã�� �Լ��� ����
        (����)
        �������� ���� ����� ��ȯ��ó���� ��� �� ���ΰ�?
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
        
        //Cube���� Target�� ���ϴ� Raycast�Լ�
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
        //Cube�� �Ӹ������� �Ʒ��� ���ϴ� Raycast�Լ� �ۼ�
        Vector3 origin = transform.position + Vector3.up * 100f;        
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        layerMask = ~layerMask;
        if(Physics.Raycast(origin, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {           
        }      
        Debug.DrawRay(origin, Vector3.down*100, Color.black);

        //�������̰� �ִ� ���ӿ�����Ʈ ���� �ö󼭴� ���� ������Ʈ
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir.Set(x, 0, y);
        Vector3 gameObjectPos = transform.position;
        gameObjectPos.x += moveDir.normalized.x * Time.deltaTime * moveSpeed;
        gameObjectPos.y = hitInfo.point.y;
        gameObjectPos.z += moveDir.normalized.z * Time.deltaTime * moveSpeed;
        transform.position = gameObjectPos;
        */
        //[�����ذ�]
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir.Set(x, 0, y);
        //Player���̾ ���̾��ũ�� ����Ͽ� ������ ������ ��ǥ�� ���
        Vector3? heightPos = GetIntersectPos(transform.position, LayerMask.NameToLayer("Player"));
        //
        Vector3 gameObjectPos = transform.position;
        gameObjectPos.x += moveDir.normalized.x * Time.deltaTime * moveSpeed;
        gameObjectPos.y = heightPos.HasValue ? heightPos.Value.y : transform.position.y;
        gameObjectPos.z += moveDir.normalized.z * Time.deltaTime * moveSpeed;
        transform.position = gameObjectPos;
        Debug.Log(gameObjectPos);
        //���׿�����
        //����? ���ϰ�� ���� : �����ϰ�� ����
    }
}
