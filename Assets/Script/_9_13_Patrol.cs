using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_13_Patrol : MonoBehaviour
{
    //public Vector3 [] wayPoints;
    int curIndex;
    public List<Vector3> wayPoints;
    Vector3 end;
    float moveSpeed;
    void Start()
    {
        //end = wayPoints[0];
        end = wayPoints[0];
        curIndex = 0;
        moveSpeed = 4f;
    }

    void Update()
    {
        transform.position = 
            Vector3.MoveTowards(transform.position, end, Time.deltaTime * moveSpeed);
        /*
        if(transform.position == end)
        {
            ++curIndex;
            if (curIndex >= wayPoints.Length)
                curIndex = 0;
            end = wayPoints[curIndex];
        }
        */
        if (transform.position == end)
        {
            ++curIndex;
            if (curIndex >= wayPoints.Count)
                curIndex = 0;
            end = wayPoints[curIndex];
        }

    }
}
