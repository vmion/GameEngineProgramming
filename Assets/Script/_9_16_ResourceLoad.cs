using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_16_ResourceLoad : MonoBehaviour
{
    
    void Start()
    {
        //Resource.Load �Լ�
        //�޸𸮿� �ε��Ѵ�.(ȭ�鿡 �ν��Ͻ��� �����ϴ� ���� �ƴϴ�)
        //����Ȯ���ڸ� ������� �ʾƾ��Ѵ�.
        //���� ������ /�� \\��� ����� �� �ִ�.
        GameObject obj_1 = Resources.Load("Golem") as GameObject;
        GameObject obj_2 = Resources.Load<GameObject>("Golem");
        //���� ������ ������ ��� ���� ������ ���
        //���� �����ڴ� /�� ��������2�� ��� ��밡��
        GameObject obj_3 = Resources.Load<GameObject>("Character/TrollGiant");

        GameObject[] objs = Resources.LoadAll<GameObject>("Character");
        //ĳ���� ������ �����ϴ� ���� ���

        //�ν��Ͻ� ����(Ŭ������ ��ü)
        GameObject createObject = GameObject.Instantiate<GameObject>(obj_3);
        createObject.transform.position = new Vector3(3, 3, 3);
        createObject.name = "Troll";
        
    }
        
    void Update()
    {
        
    }
}
