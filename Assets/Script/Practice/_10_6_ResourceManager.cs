using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_ResourceManager : SingleTon<_10_6_ResourceManager>
{
    List<GameObject> rcChaList;
    const string rcChafolder = "Character";
    public void LoadrcCharacter()
    {
        rcChaList = new List<GameObject>();
        GameObject[] objs = Resources.LoadAll<GameObject>(rcChafolder);
        foreach (GameObject one in objs)
            rcChaList.Add(one);
    }
    public GameObject GetRcCharacter(string _name)
    {
        return rcChaList.Find(o => (o.name.Equals(_name)));
    }
}
