// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.PlayerLoop;

using UnityEngine;

public class Undead : MonoBehaviour {
    [Header("Drag and Drop references here")]
    public HelperClass helperClassRef;

    public SoulCount soulRef;
    public Rebirth rebirthRef;

    // Trying TextMeshProUGUI 
    // public TextMeshProUGUI statusText;
    // public TextMeshProUGUI purchaseCostsText;
    // public TextMeshProUGUI upgradeCostsText;
    // public TextMeshProUGUI totalProductionText;

    [Header("Configurable values")] [SerializeField]
    private string name = "Zombie";

    [SerializeField] private Sprite spriteImage;
    [SerializeField] private int cost = 100;
    public int productionRate = 1;

    public int Count {
        get => PlayerPrefs.GetInt("Owned" + name, 0);
        set => PlayerPrefs.SetInt("Owned" + name, value);
    }

    public int Level {
        get => PlayerPrefs.GetInt("Level" + name, 0);
        set => PlayerPrefs.SetInt("Level" + name, value);
    }


    public double totalProduction;

    public float undeadProductionPerSecond = 1f;
    float elapsedTime;

    private int totalPurchaseCost;
    private int totalUpgradeCost;

    [SerializeField] private float purchaseCostMultiplier = 1.05f;
    [SerializeField] private float upgradeCostMultiplier = 1.05f;
    [SerializeField] public float upgradeProductionMultiplier = 1.05f;

    private int PurchaseIsAffordable {
        get {
            var tempDouble = helperClassRef.StringToDouble(soulRef.Souls);
            if (tempDouble >= totalPurchaseCost) {
                return 1;
            } else {
                return 0;
            }
        }
    }

    private int UpgradeIsAffordable {
        get {
            var tempDouble = helperClassRef.StringToDouble(soulRef.Souls);
            if (tempDouble >= totalUpgradeCost) {
                return 1;
            } else {
                return 0;
            }
        }
    }

    void Start() {
        CalculateTotalCost();
        CalculateTotalProduction();
        DisplayTexts();
    }

    void Update() {
        ProductionTimer();
        CalculateTotalCost();
        DisplayTexts();
    }

    void ProductionTimer() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.undeadProductionPerSecond) {
            UndeadProduction();
            this.elapsedTime -= this.undeadProductionPerSecond;
        }
    }

    private void CreateUndead() {
        DisplayTexts();
        if (PurchaseIsAffordable == 0) {
            return;
        }

        Count += 1;
        double tempDouble = helperClassRef.StringToDouble(soulRef.Souls);
        tempDouble -= totalPurchaseCost;
        helperClassRef.DoubleToString(tempDouble, "Souls");
        DisplayTexts();
    }

    private void UpgradeUndead() {
        DisplayTexts();
        if (UpgradeIsAffordable == 0) {
            return;
        }

        Level += 1;
        double tempDouble = helperClassRef.StringToDouble(soulRef.Souls);
        tempDouble -= totalUpgradeCost;
        helperClassRef.DoubleToString(tempDouble, "Souls");
        DisplayTexts();
    }

    public void UndeadProduction() {
        CalculateTotalProduction();

        double amountOfSouls = helperClassRef.StringToDouble(soulRef.Souls);
        double totalAmountOfSouls = helperClassRef.StringToDouble(soulRef.TotalSoulsOwned);

        var tempSoulDouble = amountOfSouls + totalProduction;
        var tempTotalDouble = totalAmountOfSouls + totalProduction;

        helperClassRef.DoubleToString(tempSoulDouble, "Souls");
        helperClassRef.DoubleToString(tempTotalDouble, "TotalSoulsOwned");
    }

    public void CalculateTotalCost() {
        totalPurchaseCost = Mathf.RoundToInt(this.cost * Mathf.Pow(purchaseCostMultiplier, Count));
        totalUpgradeCost = Mathf.RoundToInt(this.cost * Mathf.Pow(upgradeCostMultiplier, Level));
    }

    public double CalculateTotalProduction() {
        totalProduction =
            Mathf.RoundToInt(this.Count * (this.productionRate * Mathf.Pow(upgradeProductionMultiplier, Level)));
        double tempDouble = helperClassRef.StringToDouble(rebirthRef.RebirthModifier);
        if (tempDouble != 0) {
            totalProduction *= tempDouble;
        }

        return totalProduction;
    }

    public void CreateUndeadButton() {
        CreateUndead();
    }

    public void UpgradeUndeadButton() {
        UpgradeUndead();
    }

    public void DisplayTexts() {
        helperClassRef.libraryRef.statusText.text =
            $"{Count}x {name} = {productionRate * Count} souls/second (Level{Level})";
        helperClassRef.libraryRef.purchaseCostsText.text = $"Zombie Purchase costs: {this.totalPurchaseCost} souls";
        helperClassRef.libraryRef.upgradeCostsText.text = $"Zombie Upgrade costs: {this.totalUpgradeCost} souls";
        helperClassRef.libraryRef.totalProductionText.text = $"Total production: {this.totalProduction} souls/second";
    }
}