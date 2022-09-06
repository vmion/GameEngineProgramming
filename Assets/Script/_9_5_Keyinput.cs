using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_5_Keyinput : MonoBehaviour
{
    Vector3 dir;
    float moveSpeed;
    public GameObject Item;
    public Vector3 playerAreaMin;
    public Vector3 playerAreaMax;
        
    void Start()
    {
        moveSpeed = 2f;        
    }
    public void KeyCodeMove()
    {
        dir = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1f;
        }
        Vector3 tmp = transform.position;
        tmp += dir * Time.deltaTime * moveSpeed;
        transform.position = tmp;

        if (Item != null)
        {
            float Distance = Vector3.Distance(transform.position, Item.transform.position);
            if (Distance <= 1f)
            {
                if (Item.activeSelf == true)
                    Debug.Log("Item 획득");
                Item.SetActive(false);
            }
        }
    }
    void Update()
    {        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(x!=0)
            Debug.Log("x축 입력 = " + x);
        if(y!=0)
            Debug.Log("y축 입력 = " + y);
        dir.Set(x, y, 0);
        Vector3 tmp = transform.position;
        tmp.x += dir.normalized.x * Time.deltaTime * moveSpeed;
        tmp.y += dir.normalized.y * Time.deltaTime * moveSpeed;
        

        if (tmp.x >= playerAreaMin.x && tmp.x <= playerAreaMax.x &&
            tmp.y >= playerAreaMin.y && tmp.y <= playerAreaMax.y &&
            tmp.z >= playerAreaMin.z && tmp.z <= playerAreaMax.z)
        {
            transform.position = tmp;
        }
        //에디터뷰에 선그리기
        Debug.DrawLine(transform.position, Item.transform.position, Color.red);
    }
}
