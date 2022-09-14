using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_14_Mesh : MonoBehaviour
{
    MeshFilter mshfilter;
    void Start()
    {
        mshfilter = GetComponent<MeshFilter>();
        Debug.Log("정점(버텍스)정보출력");
        //정점의 자료형 Vector3
        Vector3[] arrayVertex = mshfilter.mesh.vertices;

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

        BoxCollider collider = gameObject.AddComponent<BoxCollider>();

        Debug.Log("트라이앵글(폴리곤인덱스)정보출력");
        //폴리곤 인덱스의 자료형 int
        foreach (int one in mshfilter.mesh.triangles)
        {
            Debug.Log(one);
        }
        Debug.Log("UV좌표정보출력");
        //UV좌표의 자료형 Vector2
        foreach (Vector2 one in mshfilter.mesh.uv)
        {
            Debug.Log(one);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
