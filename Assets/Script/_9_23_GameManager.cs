using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_23_GameManager : MonoBehaviour
{
    // 캐릭터 컴포넌트를 _9_23_GameManager 클래스에서 알고 있으려면
    // 지금까지 사용한 방식
    // 그런데 _9_23_SingleTonCharacter 클래스가 싱글톤 패턴이라면 아래와 같은 선언이 필요없다.
    // public _9_23_SingleTonCharacter player;
    void Start()
    {
        // 싱글톤이 적용되지 않았을 경우의 클래스 맴버 함수 호출
        // player.Test();
        // 싱글톤 패턴이 적용되었을 경우 클래스 맴버 함수 호출
        _9_23_SingletonCharacter.instance.Test();
        Debug.Log("");
        ResourceManager.instance.LoadrcCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }
}


