using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : SingleTon<ResourceManager>
{
    List<GameObject> rcCharacterList;
    
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
}
