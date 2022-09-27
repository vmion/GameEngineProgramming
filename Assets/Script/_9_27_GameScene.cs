using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_27_GameScene : MonoBehaviour
{
    List<GameObject> chaList;
    Vector3 tmp;
    void Awake()
    {
        chaList = new List<GameObject>();        
    }
    public void CreateInstance(string _name)
    {
        
        GameObject rcObj = ResourceManager.instance.GetCharacterRc("TrollGiant");        
        for (int i = 0; i < 10; i++)
        {
            if (rcObj != null)
            {
                GameObject instance = GameObject.Instantiate<GameObject>(rcObj, Vector3.zero, Quaternion.identity);
                instance.name = "TrollGiant_";
                chaList.Add(instance);
                instance.transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-3f, 3f), Random.Range(0f, 10f));          
            }
        }
    }
    void Start()
    {
        CreateInstance("Character/TrollGiant");        
    }
}
