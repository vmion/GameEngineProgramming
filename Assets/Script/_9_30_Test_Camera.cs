using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_30_Test_Camera : MonoBehaviour
{
    public _9_30_Test_Player Player;
    float xmove = 2; // X축 누적 이동량 
    float ymove = 25; // Y축 누적 이동량 
    float distance = 3f;
    private int toggleView = 3; // 1=1인칭, 3=3인칭 
    private float wheelspeed = 10.0f;
    private Vector3 Player_Height;
    private Vector3 Player_Side;
    void Start()
    {        
        Player_Height = new Vector3(0, 1.1f, 0f);
        Player_Side = new Vector3(-0.5f, 0f, 0f);
    }

    void Update()
    {         
        if (Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X");            
            ymove -= Input.GetAxis("Mouse Y");             
        }
        
        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        
        if (Input.GetKeyDown(KeyCode.Q))
            toggleView = 4 - toggleView;        
        if (toggleView == 3)
        {            
            distance -= Input.GetAxis("Mouse ScrollWheel") * wheelspeed;            
            if (distance < 3f) distance = 3f;
            if (distance > 15.0f) distance = 15.0f;
        }        
        if (toggleView == 1)
        {
            Vector3 Eye = Player.transform.position + Player_Height;
            Vector3 reverseDistance = new Vector3(0.0f, 0.0f, 0.5f);             
            transform.position = Eye + transform.rotation * reverseDistance;
            
        }
        else if (toggleView == 3)
        {
            Vector3 Eye = Player.transform.position
                + transform.rotation * Player_Side + Player_Height;
            Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
            transform.position = Eye - transform.rotation * reverseDistance;
        }
    }
}
