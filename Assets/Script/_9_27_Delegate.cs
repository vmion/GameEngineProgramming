using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//1.Update함수에서 조건문을 한번만 사용하여 특정 이벤트에만 함수호출을 할 수 있는
//프로그램 코드를 작성하시오. 단, 함수 호출은 1번만 한다.

//반환형식이 void이고 매개변수가 없는 델리게이트
public delegate void Do();

public class _9_27_Delegate : MonoBehaviour
{
    Do doFunc;
    Do doAnother;
    //<매개변수의 자료형>, 리턴값이 없는 함수에 사용
    Action<float> actDo;
    //<매개변수의 자료형, 반환형식(리턴값)>
    Func<int,bool> func;
    //<반환형식>만 존재
    Func<bool> func2;
        
    public Do DOADD 
    { 
        get { return doAnother; } 
        set { doAnother += value; }
    }
    public Do DOSET
    {
        get { return doAnother; }
        set { doAnother = value; }
    }
    void Start()
    {
        doFunc = null;
        doAnother = null;
        DOADD = Test;
        DOADD = Test;
        doAnother();
        doAnother -= Test;
        Debug.Log("doAnother -= Test 실행후");
        doAnother();
        //Action 테스트
        actDo = Test2;
        actDo(100f);
        //Func 테스트
        func = Test3;
        bool bResult = func(200);
        Debug.Log(bResult);
                
    }
    public void Test()
    {
        Debug.Log("Test함수 설명");
    }
    public void Test2(float _data)
    {
        Debug.Log(_data);
    }
    public bool Test3(int _data)
    {
        Debug.Log("Test3 함수 호출");
        return (_data > 100) ? true : false ;
    }
    /*
    public void SetFunction(Do _do)
    {
        doAnother = _do;
    }
    public void SetAddFunction(Do _do)
    {
        doAnother += _do;
    }
    */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            //Test함수를 대입
            doFunc += Test;
            doFunc += Test;
            //Test함수가 호출된다.
            //doFunc();

            Delegate[] arrFunc = doFunc.GetInvocationList();
            ((Do)arrFunc[0])();
            ((Do)arrFunc[1])();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            //Test함수를 대입
            doFunc = null;
        }
        //
        if (doFunc != null)
        {
            doFunc();
            doFunc -= doFunc;
        }
    }
}
