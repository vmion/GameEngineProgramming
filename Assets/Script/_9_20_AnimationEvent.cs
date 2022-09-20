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
        //애니메이션 클립정보가 모두 반환됨
        Debug.Log("애니메이션 클립의 개수는 총" + clipInfos.Length + "개 입니다.");
        foreach(AnimatorClipInfo one in clipInfos)
        {
            Debug.Log(one.clip.name + "의 길이는" + one.clip.length + "초 입니다.");
        }
        //애니메이션 클립의 이름과 길이를 불러온다.
        */
        
    }
    public void MoveAnimEvent()
    {
        Debug.Log("MoveAnimEvent 함수 호출");
    }
    //애니메이션 뷰의 애니메이션 이벤트를 사용하지 않고 진행도 80%이상일때 이벤트를 발생시킨다.
    void Update()
    {
        //애니메이션의 진행도가 80프로 이상일때마다 MoveAnimEvent를 발생시킨다.
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Move"))
        {
            duration = ani.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
            refCount = (int)ani.GetCurrentAnimatorStateInfo(0).normalizedTime;
                        
            //float ratio = duration * 100f;
            //Debug.Log("애니메이션 진행 비율 = "+ ratio + "%");
            //애니메이션 진행시간이 80%이상이라면 이벤트 발생
            
            //refCount는 1초마다증가, callCount는 함수가 발동할때마다 증가하는데
            //애니메이션 길이가 1초이기 때문에 refCount와 callCount가 1차이가 나면
            //정상적으로 작동되게 된다.
            //2차이가 나면 doEvent를 2번 호출해줘야 한다.
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
