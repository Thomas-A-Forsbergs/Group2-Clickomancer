using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class Undead : MonoBehaviour {
    [Header("Drag and Drop references here")]
    public HelperClass _helperClassRef;
    public SoulCount soulRef;
    public Rebirth rebirthRef;


    // Trying TextMeshProUGUI 
    public TextMeshProUGUI TMP_statusText;
    public TextMeshProUGUI TMP_purchaseCostsText;
    public TextMeshProUGUI TMP_upgradeCostsText;
    public TextMeshProUGUI TMP_totalproductionText;
    [SerializeField] private Sprite sprite;

    [Header("Configurable values")] [SerializeField]
    private string name = "Zombie";

    [SerializeField] private int cost = 100;
    public int productionRate = 1;
    [SerializeField] private int count = 0;
    [SerializeField] private int level = 0;
    [SerializeField] private float purchaseCostMultiplier = 1.05f;
    [SerializeField] private float upgradeCostMultiplier = 1.05f;
    [SerializeField] public float upgradeProductionMultiplier = 1.05f;

    public double totalProduction;
    private int totalPurchaseCost;
    private int totalUpgradeCost;

    public float undeadProductionPerSecond = 1f;
    float elapsedTime;

    public int Count {
        get => PlayerPrefs.GetInt("Owned" + name, 0);
        set => PlayerPrefs.SetInt("Owned" + name, value);
    }

    public int Level {
        get => PlayerPrefs.GetInt("Level" + name, 0);
        set => PlayerPrefs.SetInt("Level" + name, value);
    }

    //public bool PurchaseIsAffordable => soulRef.Souls >= this.totalPurchaseCost;
    //public bool UpgradeIsAffordable => soulRef.Souls >= this.totalUpgradeCost;

    public void DisplayTexts() {
        this.TMP_statusText.text = $"{Count}x {name} = {productionRate * Count} souls/second (Level{Level})";
        this.TMP_purchaseCostsText.text = $"Zombie Purchase costs: {this.totalPurchaseCost} souls";
        this.TMP_upgradeCostsText.text = $"Zombie Upgrade costs: {this.totalUpgradeCost} souls";
        this.TMP_totalproductionText.text = $"Total production: {this.totalProduction} souls/second";
    }

    void Start()
    {
        CalculateTotalCost();
        CalculateTotalProduction();
        DisplayTexts();
    }

    void Update() {
        //ProductionTimer();
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
        //if (!PurchaseIsAffordable) {
        //    return;
        //}

        Count += 1;
        //soulRef.Souls -= totalPurchaseCost;
        DisplayTexts();
    }

    private void UpgradeUndead() {
        //if (!UpgradeIsAffordable) {
        //    return;
        //}

        Level += 1;
        //soulRef.Souls -= totalUpgradeCost;
        DisplayTexts();
    }

    public void UndeadProduction() {
        CalculateTotalProduction();
        //soulRef.Souls += totalProduction;
        //soulRef.TotalSoulsOwned += totalProduction;
    }

    public void CalculateTotalCost() {
        totalPurchaseCost = Mathf.RoundToInt(this.cost * Mathf.Pow(purchaseCostMultiplier, Count));
        totalUpgradeCost = Mathf.RoundToInt(this.cost * Mathf.Pow(upgradeCostMultiplier, Level));
    }

    public double CalculateTotalProduction() {
        totalProduction =
            Mathf.RoundToInt(this.Count * (this.productionRate * Mathf.Pow(upgradeProductionMultiplier, Level)));
        var tempDouble = _helperClassRef.StringToDouble(rebirthRef.RebirthModifier);
        if (tempDouble != 0)
        {
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
}