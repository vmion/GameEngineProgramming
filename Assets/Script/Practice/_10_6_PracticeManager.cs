using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _10_6_PracticeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _10_6_InstanceManager.instance.Initialize();
        _10_6_InstanceManager.instance.CreatePlayer("TrollGiant");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
