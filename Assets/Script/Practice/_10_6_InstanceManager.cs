using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public abstract class IMonsterFactory
{
    virtual public void CreateMonster() { }
}
public class KnightFactory : IMonsterFactory
{
    public override void CreateMonster()
    {
        base.CreateMonster();
    }
}
public class MagicianFactory : IMonsterFactory
{
    public override void CreateMonster()
    {
        base.CreateMonster();
    }
}
*/
public struct CHARINFO
{
    public string name { get; set; }
}
public class _10_6_InstanceManager : SingleTon<_10_6_InstanceManager>
{
    //ResourceManager를 이용하여 인스턴스를 생성
    List<_10_6_Character<CHARINFO>> characterList;
    _10_6_Player player;
    _10_6_Monster monster;
    public void Initialize()
    {
        characterList = new List<_10_6_Character<CHARINFO>>();
        _10_6_ResourceManager.instance.LoadrcCharacter();
    }
    public void CreatePlayer(string _name)
    {
        GameObject obj = _10_6_ResourceManager.instance.GetRcCharacter(_name);
        if(obj != null)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(obj);
            player = createObj.AddComponent<_10_6_Player>();            
            createObj.layer = LayerMask.NameToLayer("Player");
            Vector3? objPos = GeometryHelper.GetTerrainHeightPos(new Vector3(3,0,3));
            CHARINFO info = new CHARINFO();
            info.name = "zeroine";
            player.info = info;
            if (objPos.HasValue)
            {
                player.transform.position = objPos.Value;
            }

        }
    }
    public void CreateMonster(string _name)
    {
        GameObject mob = _10_6_ResourceManager.instance.GetRcCharacter(_name);
        if (mob != null)
        {           
            GameObject createObj = GameObject.Instantiate<GameObject>(mob);
            //_10_6_Character<CHARINFO> addedScript = createObj.AddComponent<_10_6_Monster>();
            monster = createObj.AddComponent<_10_6_Monster>();
            createObj.layer = LayerMask.NameToLayer("Monster");
            Vector3? objPos = GeometryHelper.GetTerrainHeightPos(new Vector3(-3,0,-3));
            CHARINFO info = new CHARINFO();
            info.name = "Goblin";            
            if (objPos.HasValue)
            {
                player.transform.position = objPos.Value;
            }
        }
    }
}
