using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_23_GameManager : MonoBehaviour
{
    // ĳ���� ������Ʈ�� _9_23_GameManager Ŭ�������� �˰� ��������
    // ���ݱ��� ����� ���
    // �׷��� _9_23_SingleTonCharacter Ŭ������ �̱��� �����̶�� �Ʒ��� ���� ������ �ʿ����.
    // public _9_23_SingleTonCharacter player;
    void Start()
    {
        // �̱����� ������� �ʾ��� ����� Ŭ���� �ɹ� �Լ� ȣ��
        // player.Test();
        // �̱��� ������ ����Ǿ��� ��� Ŭ���� �ɹ� �Լ� ȣ��
        _9_23_SingletonCharacter.instance.Test();
        Debug.Log("");
        ResourceManager.instance.LoadrcCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


