using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_16_ResourceLoad : MonoBehaviour
{
    
    void Start()
    {
        //Resource.Load 함수
        //메모리에 로드한다.(화면에 인스턴스를 생성하는 것이 아니다)
        //파일확장자를 명시하지 않아야한다.
        //폴더 구분을 /와 \\모두 사용할 수 있다.
        GameObject obj_1 = Resources.Load("Golem") as GameObject;
        GameObject obj_2 = Resources.Load<GameObject>("Golem");
        //하위 폴더가 존재할 경우 하위 폴더명 명시
        //폴더 구분자는 /와 역슬래시2개 모두 사용가능
        GameObject obj_3 = Resources.Load<GameObject>("Character/TrollGiant");

        GameObject[] objs = Resources.LoadAll<GameObject>("Character");
        //캐릭터 폴더에 존재하는 에셋 모두

        //인스턴스 생성(클래스의 객체)
        GameObject createObject = GameObject.Instantiate<GameObject>(obj_3);
        createObject.transform.position = new Vector3(3, 3, 3);
        createObject.name = "Troll";
        
    }
        
    void Update()
    {
        
    }
}
