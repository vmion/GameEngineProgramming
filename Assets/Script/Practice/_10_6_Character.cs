using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    public void oneSkill();
    public void twoSkill();
    public void threeSkill();
    public void fourSkill();    
}

public class _10_6_Character<T> : MonoBehaviour, ISkill
{
    public T info { get; set; }
    void Start()
    {
        
    }
    virtual public void oneSkill()
    {

    }
    virtual public void twoSkill()
    {

    }
    virtual public void threeSkill()
    {

    }
    virtual public void fourSkill()
    {

    }

    void Update()
    {
        
    }
}
