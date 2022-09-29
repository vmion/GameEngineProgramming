using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_29_LineRenderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    Vector3 end;
    float lineSpeed;
    Vector3 targetPosition;
    
    void Start()
    {
        lineRenderer.SetPosition(0,transform.position);
        //lineRenderer.SetPosition(1,new Vector3(10,0,0));
        end = transform.position;        
        FindTarget();
        lineSpeed = 3.0f;
    }
    void CreateSphere()
    {
        GameObject createdObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        createdObj.transform.position = targetPosition;
        createdObj.tag = "Sphere";
    }
    void FindTarget()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity)) ;
        {
            targetPosition = hitInfo.point;
        }
    }
    void FindInterSectPosition()
    {
        Vector3 dir = end - transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, dir.normalized, out hitInfo, Mathf.Infinity))
        {
            if(hitInfo.collider.CompareTag("Board"))
            {
                //if (end == targetPosition)
                    //CreateSphere();                
            }
            if(hitInfo.collider.CompareTag("Monster"))
            {
                GameObject.Destroy(hitInfo.collider.gameObject);
            }
            targetPosition = hitInfo.point;            
            lineRenderer.SetPosition(0,transform.position);
        }
    }
        
    void Update()
    {
        FindTarget();    
        end = Vector3.MoveTowards(end, targetPosition, Time.deltaTime * lineSpeed);
        lineRenderer.SetPosition(1, end);
        FindInterSectPosition();
    }
}
