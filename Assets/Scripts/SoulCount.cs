using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class SoulCount : MonoBehaviour
{
    
    [Header("Drag and Drop reference here")]
    public TMPro.TMP_Text soulText;
    
    [Header("Configurable values")]
    public int soulsPerClick = 1;
    public float upgradeMultiplier = 1.5f;
    public int upgradeLevel = 0;
    public int upgradeCost = 100;
    public float upgradeCostMultiplier = 1.1f;
    private int totalCost;
    
    private bool IsAffordable => Souls >= totalCost;
    
    
    public int Souls
    {
        get => PlayerPrefs.GetInt("Souls", 0);
        set => PlayerPrefs.SetInt("Souls", value);
    }
    public void Update()
    {
        CalculateTotalCost();
        soulText.text = "Souls:" + Souls;
    }

    public void Click()
    {
        Souls +=  Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, upgradeLevel)));

    }
    public void PurchaseUpgrade()
    {
        if (!IsAffordable)
        {
            return;
        }
        upgradeLevel++;
        Souls -= totalCost;
    }

    private void CalculateTotalCost()
    {
        totalCost = Mathf.RoundToInt(upgradeCost * Mathf.Pow(upgradeCostMultiplier, upgradeLevel));
    }
}