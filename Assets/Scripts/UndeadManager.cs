using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeadManager : MonoBehaviour
{

    public Undead[] undeadChildren;
    
    // Start is called before the first frame update
    void Start()
    {
        undeadChildren = GetComponentsInChildren<Undead>();
        for (int i = 0; i < undeadChildren.Length; i++) 
        {
            undeadChildren[i].CalculateTotalProduction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
