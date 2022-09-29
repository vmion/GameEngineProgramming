using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_29_Barrack : MonoBehaviour
{
    float elapsed;
    public int barrackIndex;
    void Start()
    {
        elapsed = 0f;
    }    
    void CreatePrimitive()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 4f)
        {
            elapsed -= 4f;
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            obj.name = "Creature";
            obj.transform.position = transform.position;
            obj.tag = "Monster";
            _9_29_Monster script = obj.AddComponent<_9_29_Monster>();            
            script.END = new Vector3(transform.position.x, transform.position.y, -8.3f);
            script.BarrackIndex = barrackIndex;
            script.MoveSpeed = 3f;
            obj.transform.position = transform.position;
        }
    }
    
    void Update()
    {
        //CreatePrimitive();
        elapsed += Time.deltaTime;
        if(elapsed >= 4f)
        {
            elapsed -= 4f;
            GameObject createdMob = GameObject.CreatePrimitive(PrimitiveType.Capsule);            
            createdMob.tag = "Monster";
            _9_29_Monster script = createdMob.AddComponent<_9_29_Monster>();            
            script.END = new Vector3(transform.position.x, transform.position.y, -8.3f);
            script.BarrackIndex = barrackIndex;
            script.MoveSpeed = 1.5f;
            createdMob.transform.position = transform.position;
        }
    }
}
