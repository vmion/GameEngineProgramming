using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_Test_Manager : MonoBehaviour
{
    List<GameObject> rcCharacterList;
    List<GameObject> chaList;
    Vector3 tmp;
    GameObject Player;
    private void Awake()
    {
        LoadrcCharacter();
        chaList = new List<GameObject>();
        //Player = Resources.Load<GameObject>("Lumberjack1");
    }   

    public void LoadrcCharacter()
    {
        if (rcCharacterList == null)
            rcCharacterList = new List<GameObject>();
        GameObject[] objs = Resources.LoadAll<GameObject>("Character/");
        foreach (GameObject one in objs)
            rcCharacterList.Add(one);
    }
    public GameObject GetCharacterRc(string _name)
    {
        return rcCharacterList.Find(o => (o.name.Equals(_name)));
    }
    public void CreateInstance(string _name)
    {
        GameObject rcObj = GetCharacterRc("TrollGiant");
        for (int i = 0; i < 10; i++)
        {
            if (rcObj != null)
            {
                GameObject instance = GameObject.Instantiate<GameObject>(rcObj, Vector3.zero, Quaternion.identity);
                instance.name = "TrollGiant_";
                chaList.Add(instance);
                instance.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(1f, 3f), Random.Range(0f, 10f));
            }
        }
    }
    void Start()
    {
        CreateInstance("Character/TrollGiant");
        //GameObject obj = GameObject.Instantiate<GameObject>(Player,Vector3.zero, Quaternion.identity);
    }       
}
