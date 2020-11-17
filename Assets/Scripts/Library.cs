using System;
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
    public TMP_Text RebirthText;
    public TMP_Text BonusText;
    
    [Header("Text reference for Undead text")]
    public TMP_Text TMP_statusText;
    public TMP_Text TMP_purchaseCostsText;
    public TMP_Text TMP_upgradeCostsText;
    public TMP_Text TMP_totalproductionText;
    
    [Header("Text reference for Mana text")]
    public TMP_Text ManaText;

    // void Update() {
    //     SoulCountDisplay();
    //     RebirthDisplay();
    //     UndeadDisplay();
    //     ManaDisplay();
    // }

    // private void SoulCountDisplay()
    // {
    //     upgradeText.text = $"Upgrade to level {helperClassRef.soulsRef.UpgradeLevel +1 } Soul leech \nCost: {helperClassRef.soulsRef.totalCost}";
    //     soulsPerClickText.text = "Souls per click : " + 1 * (this.helperClassRef.soulsRef.soulsPerClick * Mathf.Pow(helperClassRef.soulsRef.upgradeMultiplier, helperClassRef.soulsRef.UpgradeLevel));
    //     soulText.text = "Souls:" + helperClassRef.soulsRef.Souls;
    // }
    //
    // private void RebirthDisplay()
    // {
    //     RebirthText.text = "Rebirth:" + helperClassRef.rebirthRef.Reborn;
    //     BonusText.text = "Bonus:" + helperClassRef.rebirthRef.RebirthModifier;
    // }
    //
    // public void UndeadDisplay() {
    //     this.TMP_statusText.text = $"{helperClassRef.Zombieref.Count}x {name} = {helperClassRef.Zombieref.productionRate * helperClassRef.Zombieref.Count} souls/second (Level{helperClassRef.Zombieref.Level})";
    //     this.TMP_purchaseCostsText.text = $"Zombie Purchase costs: {this.helperClassRef.Zombieref.totalPurchaseCost} souls";
    //     this.TMP_upgradeCostsText.text = $"Zombie Upgrade costs: {this.helperClassRef.Zombieref.totalUpgradeCost} souls";
    //     this.TMP_totalproductionText.text = $"Total production: {this.helperClassRef.Zombieref.totalProduction} souls/second";
    // }
    //
    // private void ManaDisplay()
    // {
    //     ManaText.text = "Mana:" + helperClassRef.manaRef.currentMana + "/" + helperClassRef.manaRef.MaxMana;
    // }
}
