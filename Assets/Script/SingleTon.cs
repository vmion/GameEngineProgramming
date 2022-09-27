using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T:class, new()
{
    // where 다음에는 제약조건을 명시한다.
    // T의 제약조건은
    // 참조형식이어야하고 -> class
    // 매개변수가 없는 생성자 -> new()

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
