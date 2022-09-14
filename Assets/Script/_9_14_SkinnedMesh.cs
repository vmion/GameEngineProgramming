using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_14_SkinnedMesh : MonoBehaviour
{
    new SkinnedMeshRenderer renderer;
    void Start()
    {
        renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        Debug.Log("정점(버텍스)정보출력");
        //정점의 자료형 Vector3
        Vector3[] arrayVertex = renderer.sharedMesh.vertices;

        float xMin = arrayVertex[0].x;
        float xMax = arrayVertex[0].x;
        for (int i = 1; i < arrayVertex.Length; i++)
        {
            if (xMin > arrayVertex[i].x)
                xMin = arrayVertex[i].x;
            if (xMax < arrayVertex[i].x)
                xMax = arrayVertex[i].x;
        }
        Debug.Log("정점X의 크기 = " + Mathf.Abs(xMax - xMin) * transform.localScale.x);

        float yMin = arrayVertex[0].y;
        float yMax = arrayVertex[0].y;
        for (int i = 1; i < arrayVertex.Length; i++)
        {
            if (yMin > arrayVertex[i].y)
                yMin = arrayVertex[i].y;
            if (yMax < arrayVertex[i].y)
                yMax = arrayVertex[i].y;
        }
        Debug.Log("정점Y의 크기 = " + Mathf.Abs(yMax - yMin) * transform.localScale.y);

        float zMin = arrayVertex[0].z;
        float zMax = arrayVertex[0].z;
        for (int i = 1; i < arrayVertex.Length; i++)
        {
            if (zMin > arrayVertex[i].z)
                zMin = arrayVertex[i].z;
            if (zMax < arrayVertex[i].z)
                zMax = arrayVertex[i].z;
        }        
        Debug.Log("정점Z의 크기 = " + Mathf.Abs(zMax - zMin) * transform.localScale.z);
        
        //중앙점을 구함
        Vector3 center = new Vector3((xMax - xMin) * transform.localScale.x * 0.5f,
            (yMax - yMin) * transform.localScale.y * 0.5f,
            (zMax - zMin) * transform.localScale.z * 0.5f);
        //성분별 크기를 구함
        float xSize = Mathf.Abs(xMax - xMin) * transform.localScale.x;
        float ySize = Mathf.Abs(yMax - yMin) * transform.localScale.y;
        float zSize = Mathf.Abs(zMax - zMin) * transform.localScale.z;
        Debug.Log("x의 크기 = " + xSize);
        Debug.Log("y의 크기 = " + ySize);
        Debug.Log("z의 크기 = " + zSize);
        
        //컴포넌트를 추가 후 크기와 중앙점 정보 대입
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
       // collider.size = new Vector3(xSize, zSize, ySize);
       // collider.center = new Vector3(center.x, center.z, center.y);
        //콜라이더 크기와 Bounds크기를 동일하게 적용
        collider.size = renderer.bounds.size;
        collider.center = transform.InverseTransformPoint(renderer.bounds.center);
        //renderer.bounds.size = collider.size; 유니티 버전문제로 작동 안되는 것으로 보임
    }

    void Update()
    {
        
    }
}
