using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_13_PingPong : MonoBehaviour
{
    Vector3 start;
    public Vector3 end;
    //Vector3 tmpEnd;
    float moveSpeed;
    void Start()
    {
        start = transform.position;
        //tmpEnd = end;
        moveSpeed = 2f;
    }
    public void PingPong()
    {
        transform.position = Vector3.MoveTowards(start, end, Time.deltaTime * moveSpeed);
        if (transform.position == end)
        {
            //tmpEnd = start;
            Vector3 tmp = end;
            end = start;
            start = tmp;
        }

        //else if (transform.position == start)
        //{
        //tmpEnd = end;
        //}      
    }
    void Update()
    {
              
    }
}
