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
    public int upgradeLevel;
    public int upgradeCost;

    private bool IsAffordable => Souls >= this.upgradeCost;
    
    
    public int Souls
    {
        get => PlayerPrefs.GetInt("Souls", 0);
        set => PlayerPrefs.SetInt("Souls", value);
    }
    public void Update()
    {
        soulText.text = "Souls:" + Souls;
    }

    public void Click()
    {
        //Souls +=  Mathf.RoundToInt(soulsPerClick * (upgradeLevel * upgradeMultiplier));
        Souls +=  Mathf.RoundToInt( 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, upgradeLevel)));

    }
    public void PurchaseUpgrade()
    {
        if (IsAffordable)
        {
            upgradeLevel++;
            Souls -= upgradeCost;
        }
    }
}