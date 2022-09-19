using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 1.���ӽ����߿� Ű���� �����̽��ٸ� ������ TrollGiant��� �������� �ε��Ͽ�
 �ν��Ͻ��� �����Ѵ�.
 ��, ������ ��ǥ�� X: -8���� +8, Y: -3���� +3, Z : 0���� 10������ ��������
 ������ ��ġ�� �����ȴ�.
 2.����� TrollGiant�� 1�ʸ��� �ѹ��� ȭ�鿡 ������ �ִ� ���α׷� �ڵ带 �ۼ��Ͻÿ�.
 ��, ������ ��ǥ�� X: -8���� +8, Y: -3���� +3, Z : 0���� 10������ ��������
 ������ ��ġ�� �����ȴ�.
 3.����� 20���� TrollGiant�� �ν��Ͻ��� ȭ�鿡 �����ϵ� ������ ���ӿ�����Ʈ��
 ���Ḯ��Ʈ�� �����Ѵ�. ȭ��󿡼� ���콺�� ������ ���ӿ�����Ʈ�� ��Ȱ��ȭ�Ͻÿ�.
 ���콺�ȿ� ���� �˻縦 ����Ѵ�.
 4.����� 20���� TrollGiant�� �ν��Ͻ��� ȭ�鿡 �����ϵ� ������ ���ӿ�����Ʈ��
 ���Ḯ��Ʈ�� �����Ѵ�. ȭ��󿡼� ���콺�� ������ ���ӿ�����Ʈ�� ��Ȱ��ȭ�Ͻÿ�.
 ��, ���콺�� ������ ���ӿ�����Ʈ�� ����Ʈ���� �˻��Ͽ� ��Ȱ��ȭ�Ͻÿ�.
 5.����� 20���� TrollGiant�� �ν��Ͻ��� ȭ�鿡 �����ϰ� ȭ�鿡�� ������ ���ӿ�����Ʈ��
 �±װ� Monster������ ���ϴ� ���α׷� �ڵ带 �ۼ��Ͻÿ�. ��, Monster�±״� 
 ��ϵǾ� �־�� �Ѵ�.
*/
public class _9_19_Practice_Resource : MonoBehaviour
{
    float elpased;
    GameObject rcCharacter;
    public Transform monsterParent;
    List<GameObject> monsterlist;
    //TrollGiant�� ��ũ��Ʈ�� ���� ���������� �� ��ü�̱� ������
    //���ӿ�����Ʈ�������� ����
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
            //������ �������� �̸��� Ʋ���� ���
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
            Debug.Log("1�ʸ��� �ѹ��� ȣ��");
        }
    }
    //20���� �ν��Ͻ��� ���� ���������� �ڽ����� ����
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
                //activeSelf�� get������Ƽ�� �о���� �͸� ����
                //���ӿ�����Ʈ�� ����Ȱ�����¸� ��ȯ
                if (hitInfo.collider.gameObject.activeSelf)
                {
                    Debug.Log("Ȱ��ȭ �Ǿ��ٸ� ����Ǵ� ����");
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
                    //���ڿ� Ȥ�� �ڷ��� �񱳽� ���迬���ڸ� ����� ���� ������
                    //if (monsterlist[i].name == hitInfo.collider.name)
                    //���ڿ� �񱳿����� ==���迬���ں��� Equals�Լ��� ����Ѵ�.
                    //if(monsterlist[i].name.Equals(hitInfo.collider.name))
                    //Equals�Լ��� !��!�� ���ϴ� �Լ��̴�. ���ӿ�����Ʈ �񱳵� ����
                    if (monsterlist[i].name.Equals(hitInfo.collider.gameObject))
                    {
                        Debug.Log("����Ʈ���� �˻��� ���ӿ�����Ʈ = " + monsterlist[i]);
                        monsterlist[i].SetActive(false);
                        //������ ������Ʈ�� �ϳ��̱� ������ �ݺ����� �����Ų��.
                        //���� �ٽ� ����Ʈ���� ��˻�
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
            //�����Ǵ� ������Ʈ�� "Monster"��� �±׸� �ٿ��ش�.
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
                    Debug.Log("������ ���ӿ�����Ʈ�� �±״� Monster");
                }
                else
                {
                    Debug.Log("������ ���ӿ�����Ʈ�� �±״� Monster�� �ƴմϴ�");
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
