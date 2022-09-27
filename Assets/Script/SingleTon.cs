using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T:class, new()
{
    // where �������� ���������� ����Ѵ�.
    // T�� ����������
    // ���������̾���ϰ� -> class
    // �Ű������� ���� ������ -> new()

    private static T inst;
    public SingleTon()
    {
        inst = null;
    }
    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
 
}
