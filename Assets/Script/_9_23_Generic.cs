using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterTest<T>
{
    public T data { get; set; }
    public MonsterTest()
    {
        Debug.Log("MonsterTest ������");
    }
    public void DisplayData()
    {
        Debug.Log(data);
    }
}
public class _9_23_Generic : MonoBehaviour
{
    MonsterTest<int> nick;
    MonsterTest<float> lee;
    MonsterTest<DateTime> dateTime;
    void Start()
    {
        nick = new MonsterTest<int>();
        lee = new MonsterTest<float>();
        dateTime = new MonsterTest<DateTime>();
        //T�� �����ϰ��
        nick.data = 100;
        nick.DisplayData();
        //T�� �Ǽ��ϰ��
        lee.data = 300.22f;
        lee.DisplayData();
        //T�� DateTime�ϰ��
        dateTime.data = DateTime.Now;// ����ð�
        dateTime.DisplayData();
    }
}
