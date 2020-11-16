using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SoulCount : MonoBehaviour
{
    
    [Header("Drag and Drop reference here")]
    public TMPro.TMP_Text soulText;
    public TMPro.TMP_Text upgradeText;
    public TMPro.TMP_Text soulsPerClickText;
    [Header("Configurable values")]
    public double soulsPerClick = 1;
    public float upgradeMultiplier = 1.5f;
    public int upgradeLevel = 0; 
    public int upgradeCost = 100;
    public float upgradeCostMultiplier = 1.1f;
    private int totalCost;

    private int IsAffordable
    {
        get
        {
            var tempDouble = StringToDouble(Souls);
            if (tempDouble >= totalCost)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    } 

    public void Start()
    {
        Display();
        CalculateTotalCost();
    }

    public int UpgradeLevel
    {
        get => PlayerPrefs.GetInt("UpgradeLevel", 0);
        set => PlayerPrefs.SetInt("UpgradeLevel", value);
    }
    public string Souls
    {
        get => PlayerPrefs.GetString("Souls", "0");
        set => PlayerPrefs.SetString("Souls", value);
    }

    public string TotalSoulsOwned
    {
        get => PlayerPrefs.GetString("TotalSouls", "0");
        set => PlayerPrefs.SetString("TotalSouls", value);
    }
    
    public void Update()
    {
        Display();
        CalculateTotalCost();
    }

    public void Click()
    {
        double tempSoulDouble = StringToDouble(Souls);
        double tempTotalDouble = StringToDouble(TotalSoulsOwned);
        tempSoulDouble +=  1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        tempTotalDouble +=  1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        //TotalSoulsOwned +=  Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel)));
        DoubleToString(Souls, tempSoulDouble);
        DoubleToString(TotalSoulsOwned, tempTotalDouble);
    }
    
    public void PurchaseUpgrade()
    {
        if (IsAffordable == 0)
        {
            return;
        }
        UpgradeLevel++;
        double tempDouble = StringToDouble(Souls);
        tempDouble -= totalCost;
        DoubleToString(Souls, tempDouble);
        Display();
    }
    
    private void CalculateTotalCost()
    {
        totalCost = Mathf.RoundToInt(upgradeCost * Mathf.Pow(upgradeCostMultiplier, UpgradeLevel));
    }

    private void Display()
    {
        upgradeText.text = $"Upgrade to level {UpgradeLevel +1 } Soul leech \nCost: {totalCost}";
        soulsPerClickText.text = "Souls per click : " + 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        soulText.text = "Souls:" + Souls;
    }

    public double StringToDouble(string tempString)
    {
        double stringValue = Convert.ToDouble(tempString);
        return stringValue;
    }

    public void DoubleToString(string tempString, double value)
    {
        string doubleValue = value.ToString();
        tempString = doubleValue;
    }
}
