// using System;

using UnityEngine;
using TMPro;

public class Library : MonoBehaviour {
    private HelperClass helperClassRef;

    [Header("Text reference for Soul text")]
    public TMP_Text soulText;
    public TMP_Text upgradeText;
    public TMP_Text soulsPerClickText;

    [Header("Text reference for Rebirth text")]
    public TMP_Text rebirthText;
    public TMP_Text bonusText;

    [Header("Text reference for Zombie text")]
    public TMP_Text zombieStatusText;
    public TMP_Text zombiePurchaseCostsText;
    public TMP_Text zombieUpgradeCostsText;
    public TMP_Text zombieTotalProductionText;

    [Header("Text reference for Wraith text")]
    public TMP_Text wraithStatusText; //TODO: Explain why no Usage info?
    public TMP_Text wraithPurchaseCostsText;
    public TMP_Text wraithUpgradeCostsText;
    public TMP_Text wraithTotalProductionText;

    [Header("Text reference for Mana text")]
    public TMP_Text manaText;

    [Header("Text reference for Total Undead Production text")]
    public TMP_Text totalUndeadProductionText;

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }
}