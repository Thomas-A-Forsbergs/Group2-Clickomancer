using System;
using UnityEngine;

public class HelperClass : MonoBehaviour
{
    public SoulCount soulRef;
    public Rebirth rebirthRef;
    public UndeadManager undeadRef;
    //public ManaBar manaRef;
    public Library libraryRef;

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
            soulRef.Souls = doubleValue;
        }
        else if(tempString == "TotalSoulsOwned")
        {
            soulRef.TotalSoulsOwned = doubleValue;
        }
        else if (tempString == "RebirthModifier")
        {
            rebirthRef.RebirthModifier = doubleValue;
        }
    }
}
