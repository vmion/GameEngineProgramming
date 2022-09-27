using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterTest<T>
{
    public T data { get; set; }
    public MonsterTest()
    {
        Debug.Log("MonsterTest 생성자");
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
        //T가 정수일경우
        nick.data = 100;
        nick.DisplayData();
        //T가 실수일경우
        lee.data = 300.22f;
        lee.DisplayData();
        //T가 DateTime일경우
        dateTime.data = DateTime.Now;// 현재시간
        dateTime.DisplayData();
    }
}
