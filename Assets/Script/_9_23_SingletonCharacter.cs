using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_23_SingletonCharacter : MonoBehaviour
{
    public static _9_23_SingletonCharacter instance;
    private void Awake()
    {
        instance = this;
    }
    public void Test()
    {
        Debug.Log("_9_23_SingletonCharacter�� Test�Լ�ȣ��");
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
