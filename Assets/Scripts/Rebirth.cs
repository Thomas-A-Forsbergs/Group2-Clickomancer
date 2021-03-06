﻿using UnityEngine;

public class Rebirth : MonoBehaviour {
    private HelperClass helperClassRef;
    [SerializeField] private GameObject rebirthInfoBox;

    [Header("Drag and Drop reference here")]
    public double modifierFactor = 1f;
    public int rebirthThreshold = 1000;
    // public int rebirthThresholdModifier = 10;

    public int Reborn {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }

    public string RebirthModifier {
        get => PlayerPrefs.GetString("RebirthModifier", "1");
        set => PlayerPrefs.SetString("RebirthModifier", value);
    }

    void Update() {
        Display();
    }

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    void Start() {
        Display();
    }

    // private void CalculateRebirthThresholdModifer() {
    //     rebirthThreshold *= rebirthThresholdModifier;
    // }

    private void CalculateRebirthModifer() {
        double amountofsouls = helperClassRef.StringToDouble(helperClassRef.soulRef.TotalSoulsOwned);
        if (rebirthThreshold < amountofsouls) {
            Reborn++;
            double modToAdd = amountofsouls * modifierFactor / 1000;
            double currentMod = helperClassRef.StringToDouble(RebirthModifier);
            double totalModToAdd = currentMod + modToAdd;
            helperClassRef.DoubleToString(totalModToAdd, "RebirthModifier");
            Display();
            helperClassRef.DoubleToString(0, "Souls");
            helperClassRef.DoubleToString(0, "TotalSoulsOwned");
            helperClassRef.soulRef.UpgradeLevel = 0;
            helperClassRef.undeadRef.ResetUndeadChildCountLevel();
            rebirthInfoBox.SetActive(false);
        }
    }

    public void RebirthButton() {
        CalculateRebirthModifer();
    }

    public void OpenRebirthInfoButton() {
        rebirthInfoBox.SetActive(true);
    }

    public void CloseRebirthInfoButton() {
        rebirthInfoBox.SetActive(false);
    }

    private void Display() {
        helperClassRef.libraryRef.rebirthText.text = "Rebirth:" + Reborn;
        helperClassRef.libraryRef.bonusText.text = "Bonus:" + RebirthModifier;
        helperClassRef.libraryRef.rebirthThreshold.text =
            "Souls needed for rebirth:" + rebirthThreshold.ToString(format: "1 mil");
    }
}