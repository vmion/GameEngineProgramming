using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_8_Monster : MonoBehaviour
{
    //public Transform player;
    //public GameObject player;
    public _9_8_MousePickMove player;
    void Start()
    {
        Debug.Log("�÷��̾���ӿ�����Ʈ = " + player.gameObject.name);
    }

    
    void Update()
    {
        //�̵��ϴ� ĳ���͸� �׻� �ٶ󺸴� ���� ����
        transform.LookAt(player.transform.position);
        //transform.LookAt(player.transform.position);
        //���信 �÷��̾ ���ϴ� ���� �׷����ÿ�.
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
    }
}
