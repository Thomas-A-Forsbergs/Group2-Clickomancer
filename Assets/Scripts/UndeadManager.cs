// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;

using UnityEngine;

public class UndeadManager : MonoBehaviour {
    private HelperClass helperClassRef;

    public Undead[] undeadChildren;

    // public TextMeshProUGUI totalUndeadProductionText;

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    void Start() {
        undeadChildren = GetComponentsInChildren<Undead>();
        CalculateTotalUndeadProduction();
    }

    private void Update() {
        CalculateTotalUndeadProduction();
    }

    public double CalculateTotalUndeadProduction() {
        double totalProductionValue = 0;
        for (int i = 0; i < undeadChildren.Length; i++) {
            totalProductionValue += undeadChildren[i].CalculateTotalProduction();
        }

        //TODO: Change Debug.Log to an In-Scene text-reference to show Total passive production value somewhere
        //Debug.Log("Total Child production is: " + totalProductionValue);
        helperClassRef.libraryRef.totalUndeadProductionText.text = $"Total production: {totalProductionValue}";

        return totalProductionValue;
    }

    public void ResetUndeadChildCountLevel() {
        for (int i = 0; i < undeadChildren.Length; i++) {
            undeadChildren[i].Count = 0;
            undeadChildren[i].Level = 0;
        }
    }
}