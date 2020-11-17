// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.PlayerLoop;

using UnityEngine;

public class Rebirth : MonoBehaviour {
    [Header("Drag and Drop reference here")]
    private HelperClass helperClassRef;

    public SoulCount soulRef;
    public Undead zombieRef;

    // public TMPro.TMP_Text rebirthText;
    // public TMPro.TMP_Text bonusText;

    public double modifierFactor = 1f;
    public int rebirthThreshold = 1000;

    public int Reborn {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }

    public string RebirthModifier {
        get => PlayerPrefs.GetString("RebirthModifier", "0");
        set => PlayerPrefs.SetString("RebirthModifier", value);
    }

    void Update() {
        Display();
    }

    public void RebirthButton() {
        CalculateRebirthModifer();
    }

    void Start() {
        helperClassRef = GetComponentInParent<HelperClass>();
        Display();
    }

    private void CalculateRebirthModifer() {
        double amountofsouls = helperClassRef.StringToDouble(soulRef.TotalSoulsOwned);
        if (rebirthThreshold < amountofsouls) {
            Reborn++;
            double modToAdd = amountofsouls * modifierFactor;
            double currentMod = helperClassRef.StringToDouble(RebirthModifier);
            double totalModToAdd = currentMod + modToAdd;
            helperClassRef.DoubleToString(totalModToAdd, "RebirthModifier");
            Display();
            helperClassRef.DoubleToString(0, "Souls");
            helperClassRef.DoubleToString(0, "TotalSoulsOwned");
            soulRef.UpgradeLevel = 0;
            helperClassRef.undeadRef.ResetUndeadChildCountLevel();
        }
    }

    private void Display() {
        helperClassRef.libraryRef.rebirthText.text = "Rebirth:" + Reborn;
        helperClassRef.libraryRef.bonusText.text = "Bonus:" + RebirthModifier;
    }
}