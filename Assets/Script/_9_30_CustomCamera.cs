using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_CustomCamera : MonoBehaviour
{
    public _9_30_Player player;
    Vector3 playerOldPos;
    //�÷��̾ �˰� �־���Ѵ�.
    void Start()
    {
        playerOldPos = player.transform.position;
    }
        
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 delta = player.transform.position - playerOldPos;
        transform.position += delta;
        playerOldPos = player.transform.position;
    }
}
