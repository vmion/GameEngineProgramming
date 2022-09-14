using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_14_Plane : MonoBehaviour
{    
    void Start()
    {
        //1.메시를 생성
        //2.메시정보를 대입
        //3.컴포넌트를 추가
        //4.컴포넌트에 메시를 대입
        Mesh mesh = new Mesh();

        //메시정보를 채운다
        //1.정점
        Vector3[] vertices = {new Vector3(-0.5f, 0, 0), new Vector3(0.5f, 0, 0),
            new Vector3(-0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f, 0)};
        mesh.vertices = vertices;
        //2.폴리곤 인덱스
        mesh.triangles = new int[] { 0, 1, 2 ,
                                     1, 2, 3};
        //3.정점 노멀벡터(forward 벡터)
        //4.uv(Vector2 데이터)
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };

        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material.mainTexture = Resources.Load<Texture2D>("Golem");
               
        
        
    }
        
    void Update()
    {
        
    }
}
