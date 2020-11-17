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
        CalculateTotalUndeadProduction();
    }

    private void Update()
    {
        
        CalculateTotalUndeadProduction();
    }

    public void CalculateTotalUndeadProduction()
    {
        double totalProductionValue = 0;
        for (int i = 0; i < undeadChildren.Length; i++)
        {
            totalProductionValue += undeadChildren[i].CalculateTotalProduction();
        }  
        //TODO: Change Debug.Log to an In-Scene text-reference to show Total passive production value somewhere
        Debug.Log("Total Child production is: " + totalProductionValue);
    }
    
    public void ResetUndeadChildCountLevel()
    {
        for (int i = 0; i < undeadChildren.Length; i++) 
        {
            undeadChildren[i].Count = 0;
            undeadChildren[i].Level = 0;
        }    
    }
}
