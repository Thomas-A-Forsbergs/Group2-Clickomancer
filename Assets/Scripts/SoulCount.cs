using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SoulCount : MonoBehaviour
{
    
    [Header("Drag and Drop reference here")]
    public HelperClass _helperClassRef;
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
            var tempDouble = _helperClassRef.StringToDouble(Souls);
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
        get => PlayerPrefs.GetString("TotalSoulsOwned", "0");
        set => PlayerPrefs.SetString("TotalSoulsOwned", value);
    }
    
    public void Update()
    {
        Display();
        CalculateTotalCost();
    }

    public void Click()
    {
        double tempSoulDouble = _helperClassRef.StringToDouble(Souls);
        double tempTotalDouble = _helperClassRef.StringToDouble(TotalSoulsOwned);
        tempSoulDouble +=  1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        tempTotalDouble +=  1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        _helperClassRef.DoubleToString(tempSoulDouble, "Souls");
        _helperClassRef.DoubleToString(tempTotalDouble, "TotalSoulsOwned");
    }
    
    public void PurchaseUpgrade()
    {
        if (IsAffordable == 0)
        {
            return;
        }
        UpgradeLevel++;
        double tempDouble = _helperClassRef.StringToDouble(Souls);
        tempDouble -= totalCost;
        _helperClassRef.DoubleToString(tempDouble, "Souls");
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
}
