using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_8_Monster : MonoBehaviour
{
    //public Transform player;
    //public GameObject player;
    public _9_8_MousePickMove player;
    void Start()
    {
        Debug.Log("플레이어게임오브젝트 = " + player.gameObject.name);
    }

    
    void Update()
    {
        //이동하는 캐릭터를 항상 바라보는 몬스터 구현
        transform.LookAt(player.transform.position);
        //transform.LookAt(player.transform.position);
        //씬뷰에 플레이어를 향하는 선을 그려보시오.
        Debug.DrawLine(transform.position, player.transform.position, Color.red);
    }
}
