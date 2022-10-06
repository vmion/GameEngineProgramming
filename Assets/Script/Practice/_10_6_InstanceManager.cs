using Assets.Script.Practice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
public class _10_6_InstanceManager : SingleTon<_10_6_InstanceManager>
{
    //ResourceManager를 이용하여 인스턴스를 생성
    List<_10_6_Character> characterList;
    _10_6_Player player;
    public void Initialize()
    {
        characterList = new List<_10_6_Character>();
        _10_6_ResourceManager.instance.LoadrcCharacter();
    }
    public void CreatePlayer(string _name)
    {
        GameObject obj = _10_6_ResourceManager.instance.GetRcCharacter(_name);
        if(obj != null)
        {
            GameObject createObj = GameObject.Instantiate<GameObject>(obj);
            //_10_6_Character addedScript = createObj.AddComponent<_10_6_Player>();
            //characterList.Add(addedScript);
            player = createObj.AddComponent<_10_6_Player>();
            player.gameObject.layer = LayerMask.NameToLayer("Player");
            Vector3? objPos = GeometryHelper.GetTerrainHeightPos(Vector3.zero);
            if(objPos.HasValue)
            {
                player.transform.position = objPos.Value;
            }

        }
    }
    public void CreateMonster(string _name, IMonsterFactory _factory)
    {
        GameObject mob = _10_6_ResourceManager.instance.GetRcCharacter(_name);
        if (mob != null)
        {
            _factory.CreateMonster();

            GameObject createObj = GameObject.Instantiate<GameObject>(mob);
            _10_6_Character addedScript = createObj.AddComponent<_10_6_Monster>();
            characterList.Add(addedScript);
        }
    }
}
