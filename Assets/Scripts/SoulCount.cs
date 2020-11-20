// using System;
// using Unity.Mathematics;
// using UnityEngine.UI;

using System;
using UnityEngine;

public class SoulCount : MonoBehaviour {
    [Header("Drag and Drop reference here")]
    private HelperClass helperClassRef;
    
    [Header("Configurable values")]
    public double soulsPerClick = 1;
    public float upgradeMultiplier = 1.5f;
    public int upgradeCost = 100;
    public float upgradeCostMultiplier = 1.1f;
    private int totalCost;

    private int IsAffordable {
        get {
            var tempDouble = helperClassRef.StringToDouble(Souls);
            if (tempDouble >= totalCost) {
                return 1;
            } else {
                return 0;
            }
        }
    }
    
    private void Awake()
    {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    public void Start() {
        Display();
        CalculateTotalCost();
    }
    
    public void Update() {
        Display();
        CalculateTotalCost();
    }

    public int UpgradeLevel {
        get => PlayerPrefs.GetInt("UpgradeLevel", 0);
        set => PlayerPrefs.SetInt("UpgradeLevel", value);
    }

    public string Souls {
        get => PlayerPrefs.GetString("Souls", "0");
        set => PlayerPrefs.SetString("Souls", value);
    }

    public string TotalSoulsOwned {
        get => PlayerPrefs.GetString("TotalSoulsOwned", "0");
        set => PlayerPrefs.SetString("TotalSoulsOwned", value);
    }

    public void Click() {
        double tempSouls = helperClassRef.StringToDouble(Souls);
        double tempTotalSouls = helperClassRef.StringToDouble(TotalSoulsOwned);
        tempSouls += 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        tempTotalSouls += 1 * (this.soulsPerClick * Mathf.Pow(upgradeMultiplier, UpgradeLevel));
        helperClassRef.DoubleToString(tempSouls, "Souls");
        helperClassRef.DoubleToString(tempTotalSouls, "TotalSoulsOwned");
    }

    public void PurchaseUpgrade() {
        if (IsAffordable == 0) {
            return;
        }

        UpgradeLevel++;
        double tempDouble = helperClassRef.StringToDouble(Souls);
        tempDouble -= totalCost;
        helperClassRef.DoubleToString(tempDouble, "Souls");
        Display();
    }

    private void CalculateTotalCost() {
        totalCost = Mathf.RoundToInt(upgradeCost * Mathf.Pow(upgradeCostMultiplier, UpgradeLevel));
    }

    private void Display() {
        helperClassRef.libraryRef.upgradeText.text =
            $"Upgrade to level {UpgradeLevel + 1} Soul leech \nCost: {totalCost}";
        helperClassRef.libraryRef.soulsPerClickText.text = "Souls per click : " + 1 * (this.soulsPerClick * Mathf.Pow(
            upgradeMultiplier,
            UpgradeLevel));
        helperClassRef.libraryRef.soulText.text = "Souls:" + Souls;
    }
}