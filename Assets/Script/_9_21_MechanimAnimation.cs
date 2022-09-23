using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_21_MechanimAnimation : MonoBehaviour
{
    public Animator ani;
    public Vector3 end { get; set; } 
    float moveSpeed;
    float rotateSpeed;
    public Transform Enemy { get; set; }   
    public float attackRange { get; set; }
    void Start()
    {
        moveSpeed = 2f;
        rotateSpeed = 5f;
        end = transform.position;        
        Enemy = null;
        attackRange = 2f;
    }        
    public void TestAnimation()
    {
        //aniIndex�� �ڷ����� int�� �����߱� ������ SetInteger���
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ani.SetInteger("aniIndex", 0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ani.SetInteger("aniIndex", 1);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ani.SetInteger("aniIndex", 2);
        }
    }
    public void PlayerMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
    }
    public void PlayerRotate()
    {
        //ȸ����� - ���̸� �����Ͽ� ȸ�����
        Vector3 tmpEnd = end;
        tmpEnd.y = transform.position.y;
        Vector3 dir = tmpEnd - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, dir.normalized, Time.deltaTime * rotateSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDir.normalized);
    }
    void Update()
    {               
        //�̵�
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if(hitInfo.collider.CompareTag("Monster"))
                {
                    end = hitInfo.collider.transform.position;
                    Enemy = hitInfo.collider.transform;
                    Debug.Log("���� ����");
                }
                else if(hitInfo.collider.CompareTag("Terrain"))
                {
                    Debug.Log("���콺�� ������ ��ġ = " + hitInfo.point);
                    end = hitInfo.point;
                    Enemy = null;
                }
                else if(hitInfo.collider.CompareTag("Player"))
                {
                    Debug.Log("�÷��̾� ���� -> UI Ȱ��ȭ");
                    Enemy = null;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ani.SetTrigger("TrollGiantshout");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ani.SetTrigger("TrollGiantmagic");
        }

    }
}
