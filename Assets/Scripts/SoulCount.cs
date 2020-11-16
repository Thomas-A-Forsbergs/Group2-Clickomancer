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
    public int soulsPerClick = 1;
    public float upgradeMultiplier = 1.5f;
    public int upgradeLevel = 0; 
    public int upgradeCost = 100;
    public float upgradeCostMultiplier = 1.1f;
    private int totalCost;
    
    private bool IsAffordable => Souls >= totalCost;

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
    public int Souls
    {
        get => PlayerPrefs.GetInt("Souls", 0);
        set => PlayerPrefs.SetInt("Souls", value);
    }

    public int TotalSoulsOwned
    {
        get => PlayerPrefs.GetInt("TotalSouls", 0);
        set => PlayerPrefs.SetInt("TotalSouls", value);
    }
    
    public void Update()
    {
        Display();
        CalculateTotalCost();
    }

    public void Click()
    {
        Souls +=  Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel)));
        TotalSoulsOwned +=  Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel)));

    }
    public void PurchaseUpgrade()
    {
        if (!IsAffordable)
        {
            return;
        }
        UpgradeLevel++;
        Souls -= totalCost;
        Display();
    }
    private void CalculateTotalCost()
    {
        totalCost = Mathf.RoundToInt(upgradeCost * Mathf.Pow(upgradeCostMultiplier, UpgradeLevel));
    }

    private void Display()
    {
        upgradeText.text = $"Upgrade to level {UpgradeLevel +1 } Soul leech \nCost: {totalCost}";
        soulsPerClickText.text = "Souls per click : " + Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel)));
        soulText.text = "Souls:" + Souls;
    }
}
