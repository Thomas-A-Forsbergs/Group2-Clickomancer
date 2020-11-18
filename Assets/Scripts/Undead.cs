// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.PlayerLoop;
// using System;

using System;
using UnityEngine;

public class Undead : MonoBehaviour {
    [Header("Drag and Drop references here")]
    private HelperClass helperClassRef;

    [Header("Configurable values")]
    //private string name = "Zombie";
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
            var tempDouble = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
            if (tempDouble >= totalPurchaseCost) {
                return 1;
            } else {
                return 0;
            }
        }
    }

    private int UpgradeIsAffordable {
        get {
            var tempDouble = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
            if (tempDouble >= totalUpgradeCost) {
                return 1;
            } else {
                return 0;
            }
        }
    }

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    void Start() {
        CalculateTotalCost();
        CalculateTotalProduction();
        DisplayUndead();
    }

    void Update() {
        ProductionTimer();
        CalculateTotalCost();
        DisplayUndead();
    }

    void ProductionTimer() {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.undeadProductionPerSecond) {
            UndeadProduction();
            this.elapsedTime -= this.undeadProductionPerSecond;
        }
    }

    private void CreateUndead() {
        DisplayUndead();
        if (PurchaseIsAffordable == 0) {
            return;
        }

        Count += 1;
        double tempDouble = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
        tempDouble -= totalPurchaseCost;
        helperClassRef.DoubleToString(tempDouble, "Souls");
        DisplayUndead();
    }

    private void UpgradeUndead() {
        DisplayUndead();
        if (UpgradeIsAffordable == 0) {
            return;
        }

        Level += 1;
        double tempDouble = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
        tempDouble -= totalUpgradeCost;
        helperClassRef.DoubleToString(tempDouble, "Souls");
        DisplayUndead();
    }

    public void UndeadProduction() {
        CalculateTotalProduction();

        double amountOfSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
        double totalAmountOfSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.TotalSoulsOwned);

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

        double tempDouble = helperClassRef.StringToDouble(helperClassRef.rebirthRef.RebirthModifier);
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

    public void DisplayUndead() {
        DisplayZombieText();
        DisplayWraithText();
    }

    public void DisplayZombieText() {
        if (this.name != "Zombie")
        {
            return;
        }
        helperClassRef.libraryRef.zombieStatusText.text = $"{Count}x {name} = {productionRate * Count} souls/second (Level{Level})";
        helperClassRef.libraryRef.zombiePurchaseCostsText.text = $"{name} Purchase costs: {this.totalPurchaseCost} souls";
        helperClassRef.libraryRef.zombieUpgradeCostsText.text = $"{name} Upgrade costs: {this.totalUpgradeCost} souls";
        helperClassRef.libraryRef.zombieTotalProductionText.text = $"Total {name} production: {this.totalProduction} souls/second";
    }

    public void DisplayWraithText() {
        if (this.name != "Wraith")
        {
            return;
        }
        helperClassRef.libraryRef.wraithStatusText.text = $"{Count}x {name} = {productionRate * Count} souls/second (Level{Level})";
        helperClassRef.libraryRef.wraithPurchaseCostsText.text = $"{name} Purchase costs: {this.totalPurchaseCost} souls";
        helperClassRef.libraryRef.wraithUpgradeCostsText.text = $"{name} Upgrade costs: {this.totalUpgradeCost} souls";
        helperClassRef.libraryRef.wraithTotalProductionText.text = $"Total {name} production: {this.totalProduction} souls/second";
    }
}