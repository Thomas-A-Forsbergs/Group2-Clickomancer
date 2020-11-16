using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HelperClass : MonoBehaviour
{
    public SoulCount soulsRef;
    public Rebirth rebirthRef;

    public double StringToDouble(string tempString)
    {
        double stringValue = Convert.ToDouble(tempString);
        return stringValue;
    }

    public void DoubleToString(double value, string tempString)
    {
        string doubleValue = value.ToString();
        if (tempString == "Souls")
        {
            soulsRef.Souls = doubleValue;
        }
        else if(tempString == "TotalSoulsOwned")
        {
            soulsRef.TotalSoulsOwned = doubleValue;
        }
        else if (tempString == "RebirthModifier")
        {
            Debug.Log("I am rebirthing");
            rebirthRef.RebirthModifier = doubleValue;
        }
    }
}
