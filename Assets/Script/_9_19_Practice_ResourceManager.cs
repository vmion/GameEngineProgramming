using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_19_Practice_ResourceManager : MonoBehaviour
{
    //������ �ε�
    //�ε��� ������ �˻��Ͽ� ��ȯ
    //
    //������ ���� ����Ʈ(�÷��̾�ĳ����, ����, NPC)
    private List<GameObject> rcPlayerList;
    private List<GameObject> rcMonsterList;
    private List<GameObject> rcNpcList;
    const string rcPlayerFolder = "/Player";
    const string rcMonsterFolder = "/Monster";
    const string rcNpcFolder = "/Npc";
    private void Awake()
    {
        //rcPlayerList = new List<GameObject>();
        //rcMonsterList = new List<GameObject>();
        //rcNpcList = new List<GameObject>();
        LoadrcPlayer();
        LoadrcMonster();
        LoadrcNpc();
    }
    //�������� ����Ʈ�� ����
    void LoadrcPlayer()
    {
        //Application.dataPath�� Asset��������
        GameObject[] tmp = Resources.LoadAll<GameObject>(rcPlayerFolder);
        foreach (GameObject one in tmp)
        {
            rcPlayerList.Add(one);
        }
    }
    void LoadrcMonster()
    {
        //Application.dataPath�� Asset��������
        GameObject[] tmp = Resources.LoadAll<GameObject>(rcMonsterFolder);
        foreach (GameObject one in tmp)
        {
            rcMonsterList.Add(one);
        }
    }
    void LoadrcNpc()
    {
        //Application.dataPath�� Asset��������
        GameObject[] tmp = Resources.LoadAll<GameObject>(rcNpcFolder);
        foreach (GameObject one in tmp)
        {
            rcNpcList.Add(one);
        }
    }
    public GameObject GetrcPlayer(string _assetName)
    {
        return rcPlayerList.Find(o => (o.name.Equals(_assetName)));
    }
    public GameObject GetrcMonster(string _assetName)
    {
        return rcMonsterList.Find(o => (o.name.Equals(_assetName)));
    }
    public GameObject GetrcNpc(string _assetName)
    {
        return rcNpcList.Find(o => (o.name.Equals(_assetName)));
    }
}
