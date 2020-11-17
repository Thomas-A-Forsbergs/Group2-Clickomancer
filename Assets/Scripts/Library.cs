// using System;
using UnityEngine;
using TMPro;

public class Library : MonoBehaviour
{
    public HelperClass helperClassRef;
    
    [Header("Text reference for Soul text")]
    public TMP_Text soulText;
    public TMP_Text upgradeText;
    public TMP_Text soulsPerClickText;
    
    [Header("Text reference for Rebirth text")]
    public TMP_Text rebirthText;
    public TMP_Text bonusText;
    
    [Header("Text reference for Undead text")]
    public TMP_Text statusText;
    public TMP_Text purchaseCostsText;
    public TMP_Text upgradeCostsText;
    public TMP_Text totalProductionText;
    
    [Header("Text reference for Mana text")]
    public TMP_Text manaText;
    
    [Header("Text reference for Mana text")]
    public TMP_Text totalUndeadProductionText;
    
    private void Awake()
    {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    // void Update() {
    //     SoulCountDisplay();
    //     RebirthDisplay();
    //     UndeadDisplay();
    //     ManaDisplay();
    // }

    // private void SoulCountDisplay()
    // {
    //     upgradeText.text = $"Upgrade to level {helperClassRef.soulRef.UpgradeLevel +1 } Soul leech \nCost: {helperClassRef.soulRef.totalCost}";
    //     soulsPerClickText.text = "Souls per click : " + 1 * (this.helperClassRef.soulRef.soulsPerClick * Mathf.Pow(helperClassRef.soulRef.upgradeMultiplier, helperClassRef.soulRef.UpgradeLevel));
    //     soulText.text = "Souls:" + helperClassRef.soulRef.Souls;
    // }
    //
    // private void RebirthDisplay()
    // {
    //     rebirthText.text = "Rebirth:" + helperClassRef.rebirthRef.Reborn;
    //     bonusText.text = "Bonus:" + helperClassRef.rebirthRef.RebirthModifier;
    // }
    //
    // public void UndeadDisplay() {
    //     this.statusText.text = $"{helperClassRef.zombieRef.Count}x {name} = {helperClassRef.zombieRef.productionRate * helperClassRef.zombieRef.Count} souls/second (Level{helperClassRef.zombieRef.Level})";
    //     this.purchaseCostsText.text = $"Zombie Purchase costs: {this.helperClassRef.zombieRef.totalPurchaseCost} souls";
    //     this.upgradeCostsText.text = $"Zombie Upgrade costs: {this.helperClassRef.zombieRef.totalUpgradeCost} souls";
    //     this.totalUndeadProductionText.text = $"Total production: {this.helperClassRef.zombieRef.totalProduction} souls/second";
    // }
    //
    // private void ManaDisplay()
    // {
    //     manaText.text = "Mana:" + helperClassRef.manaRef.currentMana + "/" + helperClassRef.manaRef.maxMana;
    // }
}
