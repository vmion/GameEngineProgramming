using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_16_Character : MonoBehaviour
{
    Vector3 dir;
    float moveSpeed;
    Rigidbody rb;    
    void Start()
    {
        moveSpeed = 100f;
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        dir.Set(x, 0, y);
        rb.velocity = dir.normalized * moveSpeed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌시작게임오브젝트 = " + other.gameObject.name);
        other.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌시작게임오브젝트 = " + collision.gameObject.name);
        collision.gameObject.SetActive(false);
    }
    void Update()
    {
        
    }
}
