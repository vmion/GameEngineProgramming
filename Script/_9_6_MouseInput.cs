using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_6_MouseInput : MonoBehaviour
{
    float rotateSpeed;
    Vector3 mouseNormal;
    float scrollWheel;
    float t;
    float a;
    float b;    
    void Start()
    {
        rotateSpeed = 100f;
        t = 0f;
        a = Camera.main.fieldOfView;
        b = Camera.main.fieldOfView;
    }
    
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        float sc = Input.GetAxis("Mouse ScrollWheel");
     
        if (sc != 0)
        {
            scrollWheel = sc;
            Debug.Log("���콺 scrollWheel�� �̺�Ʈ �� =" + sc);
            a = Camera.main.fieldOfView;
            b = a + scrollWheel * 50f;
            t = 0f;
        }
            
        mouseNormal.Set(x, y, 0);
        Vector3 tmp = transform.localEulerAngles;
        tmp.y += mouseNormal.normalized.x * Time.deltaTime * rotateSpeed;
        tmp.x += mouseNormal.normalized.y * Time.deltaTime * rotateSpeed;
        transform.localEulerAngles = tmp;
        //����ī�޶� : Camera.main
        //�ε巯�� ��ũ�� �� (a����b���� ���ϴ� ����)               
        float curFOV = Mathf.Lerp(a, b, t);
        t += 8f * Time.deltaTime;
        curFOV = Mathf.Clamp(curFOV, 40f, 110f);
        Camera.main.fieldOfView = curFOV;               
    }
}
