using System;
using UnityEngine;

public class HelperClass : MonoBehaviour
{
    public SoulCount soulsRef;
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
            soulsRef.Souls = doubleValue;
        }
        else if(tempString == "TotalSoulsOwned")
        {
            soulsRef.TotalSoulsOwned = doubleValue;
        }
        else if (tempString == "RebirthModifier")
        {
            rebirthRef.RebirthModifier = doubleValue;
        }
    }
}
