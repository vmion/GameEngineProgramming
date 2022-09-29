using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_29_Monster : MonoBehaviour
{
    public Vector3 END { get; set; }
    public int BarrackIndex { get; set; }
    public float MoveSpeed { get; set; }
         
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, END, Time.deltaTime * MoveSpeed);
    }
}
