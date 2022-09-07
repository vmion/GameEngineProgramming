using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_6_MousePick : MonoBehaviour
{
    float elapsed;
    Transform target;
    void Start()
    {
        elapsed = 0f;
        target = null;
    }
    public void CreatePrimitive()
    {
        elapsed += Time.deltaTime;
        if(elapsed >= 1f)
        {
            elapsed -= 1f;
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.name = "Creature" + Random.Range(0, 100);
            obj.transform.position = new Vector3(Random.Range(-6f, 6f), 
                                                 Random.Range(3f, -3f), 
                                                 Random.Range(6f, -6f));
        }
    }    
    void Update()
    {
        CreatePrimitive();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("마우스로 선택한 게임오브젝트 = " + hit.collider.name);
                Debug.Log("마우스로 선택한 좌표 = " + hit.point);
                Debug.Log("마우스로 선택한 게임오브젝트의 트랜스폼 = " + hit.collider.transform);
                Debug.Log("마우스로 선택한 게임오브젝트의 위치 = " + hit.collider.transform.position);
                //선택한 게임오브젝트삭제
                //Destroy(hit.collider.gameObject);
                target = hit.collider.transform;
            }
        }
        if (target != null)
        {
            Vector3 dir = target.position - Camera.main.transform.position;
            Debug.DrawRay(Camera.main.transform.position, dir, Color.red);
            //Debug.DrawRay(Camera.main.transform.position, dir.normalized * dir.magnitude, Color.red);
            //dir.normalized * dir.magnitude->방향벡터 * 벡터의 크기
            //Debug.DrawLine(Camera.main.transform.position, target.position, Color.red);
        }

    }
}

