using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//1.Update�Լ����� ���ǹ��� �ѹ��� ����Ͽ� Ư�� �̺�Ʈ���� �Լ�ȣ���� �� �� �ִ�
//���α׷� �ڵ带 �ۼ��Ͻÿ�. ��, �Լ� ȣ���� 1���� �Ѵ�.

//��ȯ������ void�̰� �Ű������� ���� ��������Ʈ
public delegate void Do();

public class _9_27_Delegate : MonoBehaviour
{
    Do doFunc;
    Do doAnother;
    //<�Ű������� �ڷ���>, ���ϰ��� ���� �Լ��� ���
    Action<float> actDo;
    //<�Ű������� �ڷ���, ��ȯ����(���ϰ�)>
    Func<int,bool> func;
    //<��ȯ����>�� ����
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
        Debug.Log("doAnother -= Test ������");
        doAnother();
        //Action �׽�Ʈ
        actDo = Test2;
        actDo(100f);
        //Func �׽�Ʈ
        func = Test3;
        bool bResult = func(200);
        Debug.Log(bResult);
                
    }
    public void Test()
    {
        Debug.Log("Test�Լ� ����");
    }
    public void Test2(float _data)
    {
        Debug.Log(_data);
    }
    public bool Test3(int _data)
    {
        Debug.Log("Test3 �Լ� ȣ��");
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
            //Test�Լ��� ����
            doFunc += Test;
            doFunc += Test;
            //Test�Լ��� ȣ��ȴ�.
            //doFunc();

            Delegate[] arrFunc = doFunc.GetInvocationList();
            ((Do)arrFunc[0])();
            ((Do)arrFunc[1])();
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            //Test�Լ��� ����
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
