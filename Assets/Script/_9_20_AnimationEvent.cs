using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate void DoEvent();
public class _9_20_AnimationEvent : MonoBehaviour
{
    public Animator ani;
    float duration; 
    DoEvent doEvent;
    int callCount;
    int refCount;
    
    void Start()
    {
        doEvent = null;
        callCount = 0;
        refCount = 0;
        /*
        AnimatorClipInfo [] clipInfos = ani.GetCurrentAnimatorClipInfo(0);
        //�ִϸ��̼� Ŭ�������� ��� ��ȯ��
        Debug.Log("�ִϸ��̼� Ŭ���� ������ ��" + clipInfos.Length + "�� �Դϴ�.");
        foreach(AnimatorClipInfo one in clipInfos)
        {
            Debug.Log(one.clip.name + "�� ���̴�" + one.clip.length + "�� �Դϴ�.");
        }
        //�ִϸ��̼� Ŭ���� �̸��� ���̸� �ҷ��´�.
        */
        
    }
    public void MoveAnimEvent()
    {
        Debug.Log("MoveAnimEvent �Լ� ȣ��");
    }
    //�ִϸ��̼� ���� �ִϸ��̼� �̺�Ʈ�� ������� �ʰ� ���൵ 80%�̻��϶� �̺�Ʈ�� �߻���Ų��.
    void Update()
    {
        //�ִϸ��̼��� ���൵�� 80���� �̻��϶����� MoveAnimEvent�� �߻���Ų��.
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            duration = ani.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
            refCount = (int)ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
                        
            //float ratio = duration * 100f;
            //Debug.Log("�ִϸ��̼� ���� ���� = "+ ratio + "%");
            //�ִϸ��̼� ����ð��� 80%�̻��̶�� �̺�Ʈ �߻�
            
            //refCount�� 1�ʸ�������, callCount�� �Լ��� �ߵ��Ҷ����� �����ϴµ�
            //�ִϸ��̼� ���̰� 1���̱� ������ refCount�� callCount�� 1���̰� ����
            //���������� �۵��ǰ� �ȴ�.
            //2���̰� ���� doEvent�� 2�� ȣ������� �Ѵ�.
            if (duration >= 0.8f && refCount - callCount >= 0)
            {
                int count = (refCount - callCount) + 1;
                for(int i = 0; i < count; i++)
                    doEvent += MoveAnimEvent;
            }
        }
        if(doEvent != null)
        {
            doEvent();
            doEvent = null;
            callCount++;                       
        }
    }
}
