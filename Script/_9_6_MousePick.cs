using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _9_6_MousePick : MonoBehaviour
{
    float elapsed;
    void Start()
    {
        elapsed = 0f;
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
                Debug.Log("���콺�� ������ ���ӿ�����Ʈ = " + hit.collider.name);
                //������ ���ӿ�����Ʈ����
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
