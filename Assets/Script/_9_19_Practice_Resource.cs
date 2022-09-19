using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 1.게임실행중에 키보드 스페이스바를 누르면 TrollGiant라는 프리팹을 로드하여
 인스턴스를 생성한다.
 단, 생성시 좌표는 X: -8에서 +8, Y: -3에서 +3, Z : 0에서 10까지의 범위에서
 무작위 위치로 생성된다.
 2.실행시 TrollGiant를 1초마다 한번씩 화면에 생성해 주는 프로그램 코드를 작성하시오.
 단, 생성시 좌표는 X: -8에서 +8, Y: -3에서 +3, Z : 0에서 10까지의 범위에서
 무작위 위치로 생성된다.
 3.실행시 20개의 TrollGiant의 인스턴스를 화면에 생성하되 생성한 게임오브젝트는
 연결리스트에 저장한다. 화면상에서 마우스로 선택한 게임오브젝트를 비활성화하시오.
 마우스픽에 의한 검사를 사용한다.
 4.실행시 20개의 TrollGiant의 인스턴스를 화면에 생성하되 생성한 게임오브젝트는
 연결리스트에 저장한다. 화면상에서 마우스로 선택한 게임오브젝트를 비활성화하시오.
 단, 마우스로 선택한 게임오브젝트를 리스트에서 검색하여 비활성화하시오.
 5.실행시 20개의 TrollGiant의 인스턴스를 화면에 생성하고 화면에서 선택한 게임오브젝트의
 태그가 Monster인지를 비교하는 프로그램 코드를 작성하시오. 단, Monster태그는 
 등록되어 있어야 한다.
*/
public class _9_19_Practice_Resource : MonoBehaviour
{
    float elpased;
    GameObject rcCharacter;
    public Transform monsterParent;
    List<GameObject> monsterlist;
    //TrollGiant는 스크립트가 없는 프리팹형식 그 자체이기 때문에
    //게임오브젝트형식으로 만듬
    void Start()
    {
        elpased = 0f;
        rcCharacter = Resources.Load<GameObject>("Character/TrollGiant");
        monsterlist = new List<GameObject>();
        //Answer_3();
        //Answer_4();
        Answer_5();
    }
    public void Answer_1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tmp = Resources.Load<GameObject>("Character/TrollGiant");
            //폴더나 프리팹의 이름이 틀렸을 경우
            if (tmp == null)
                Debug.Log("Invalid assets in folder");
            GameObject createObj = GameObject.Instantiate<GameObject>(tmp);
            createObj.transform.position = new Vector3(Random.Range(-8f, 8f),
                                                       Random.Range(-3f, 3f),
                                                       Random.Range(0f, 10f));
        }
    }
    public void Answer_2()
    {
        elpased += Time.deltaTime;
        if (elpased >= 1f)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(rcCharacter);
            createObj.transform.position = new Vector3(Random.Range(-8f, 8f),
                                                       Random.Range(-3f, 3f),
                                                       Random.Range(0f, 10f)); ;

            elpased -= 1f;
            Debug.Log("1초마다 한번씩 호출");
        }
    }
    //20개의 인스턴스를 지정 범위내에서 자식으로 생성
    public void Answer_3()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(rcCharacter);
            createObj.transform.position = new Vector3(Random.Range(-8f, 8f),
                                                       Random.Range(-3f, 3f),
                                                       Random.Range(0f, 10f));
            createObj.transform.SetParent(monsterParent);
            monsterlist.Add(createObj);
        }            
    }
    public void Answer_3_1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                hitInfo.collider.gameObject.SetActive(false);
                //activeSelf는 get프로퍼티로 읽어오는 것만 가능
                //게임오브젝트의 로컬활성상태를 반환
                if (hitInfo.collider.gameObject.activeSelf)
                {
                    Debug.Log("활성화 되었다면 실행되는 구문");
                }
            }
        }
    }
    public void Answer_4()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(rcCharacter);
            createObj.transform.position = new Vector3(Random.Range(-8f, 8f),
                                                       Random.Range(-3f, 3f),
                                                       Random.Range(0f, 10f));
            createObj.transform.SetParent(monsterParent);
            monsterlist.Add(createObj);
        }
    }
    public void Answer_4_1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                for (int i = 0; i < monsterlist.Count; i++)
                {
                    //문자열 혹은 자료의 비교시 관계연산자를 사용할 수도 있지만
                    //if (monsterlist[i].name == hitInfo.collider.name)
                    //문자열 비교에서는 ==관계연산자보다 Equals함수를 사용한다.
                    //if(monsterlist[i].name.Equals(hitInfo.collider.name))
                    //Equals함수는 !값!을 비교하는 함수이다. 게임오브젝트 비교도 가능
                    if (monsterlist[i].name.Equals(hitInfo.collider.gameObject))
                    {
                        Debug.Log("리스트에서 검색한 게임오브젝트 = " + monsterlist[i]);
                        monsterlist[i].SetActive(false);
                        //선택한 오브젝트는 하나이기 때문에 반복문을 종료시킨다.
                        //이후 다시 리스트에서 재검사
                        break;
                    }
                }
            }
        }
    }
    public void Answer_5()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(rcCharacter);
            createObj.transform.position = new Vector3(Random.Range(-8f, 8f),
                                                       Random.Range(-3f, 3f),
                                                       Random.Range(0f, 10f));
            createObj.transform.SetParent(monsterParent);
            monsterlist.Add(createObj);
            //생성되는 오브젝트에 "Monster"라는 태그를 붙여준다.
            createObj.tag = "Monster";
        }
    }
    public void Answer_5_1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                if (hitInfo.collider.CompareTag("Monster"))
                {
                    Debug.Log("선택한 게임오브젝트의 태그는 Monster");
                }
                else
                {
                    Debug.Log("선택한 게임오브젝트의 태그는 Monster가 아닙니다");
                }
            }
        }
    }
    void Update()
    {
        //Answer_1();
        //Answer_2();
        //Answer_3_1();
        //Answer_4_1();
        Answer_5_1();
    }
}
