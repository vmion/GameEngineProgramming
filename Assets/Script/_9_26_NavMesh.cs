using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class _9_26_NavMesh : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator ani;
    float yVelocity;
    float smoothTime;
    bool b;
    Vector3 towardBack;
    float elapsed;
    
    void Start()
    {
        nav.destination = transform.position;
        yVelocity = 0.01f;
        smoothTime = 100.2f;
        b = false;
        towardBack = Vector3.zero;
        elapsed = 0f;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Debug.Log("좌표는" + hitInfo.point);
                nav.destination = hitInfo.point;
            }
        }
        if (nav.destination == transform.position)
        {
            ani.SetInteger("aniIndex", 0);
        }
        else
        {
            ani.SetInteger("aniIndex", 1);
        }
        
        //네비게이션 메시 에이전트의 오프셋
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //스페이스바를 눌렀을경우 진행방향 뒤로 ransform.forward만큼 이동한다.
            //nav.Move(-transform.forward * Time.deltaTime);
            b = true;
            towardBack.Set(transform.position.x - transform.forward.x*0.6f, 0, transform.position.z - transform.forward.z*0.6f);
        }
        if (b)
        {
            elapsed += Time.deltaTime;
            float dx = Mathf.SmoothDamp(transform.position.x, towardBack.x, ref yVelocity, smoothTime);
            float dz = Mathf.SmoothDamp(transform.position.z, towardBack.z, ref yVelocity, smoothTime);
            Vector3 offset = new Vector3(towardBack.x - transform.position.x, 0, towardBack.z - transform.position.z);
            nav.Move(offset);
            if (elapsed >= 0.3f)
            {
                b = false;
                elapsed =  0f;
            }

        }
        
    }
}
