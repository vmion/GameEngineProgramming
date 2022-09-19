using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_19_Practice_ResourceManager : MonoBehaviour
{
    //에셋을 로드
    //로드한 에셋을 검색하여 반환
    //
    //종류에 따른 리스트(플레이어캐릭터, 몬스터, NPC)
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
    //프리팹을 리스트에 저장
    void LoadrcPlayer()
    {
        //Application.dataPath는 Asset폴더까지
        GameObject[] tmp = Resources.LoadAll<GameObject>(rcPlayerFolder);
        foreach (GameObject one in tmp)
        {
            rcPlayerList.Add(one);
        }
    }
    void LoadrcMonster()
    {
        //Application.dataPath는 Asset폴더까지
        GameObject[] tmp = Resources.LoadAll<GameObject>(rcMonsterFolder);
        foreach (GameObject one in tmp)
        {
            rcMonsterList.Add(one);
        }
    }
    void LoadrcNpc()
    {
        //Application.dataPath는 Asset폴더까지
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
