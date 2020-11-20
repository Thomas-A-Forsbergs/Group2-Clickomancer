using System;
using UnityEngine;

public class UndeadManager : MonoBehaviour {
    private HelperClass helperClassRef;
    [NonSerialized] Undead[] undeadChildren;
    private double totalProductionValue;

    public double TotalProductionValue {
        get => totalProductionValue;
        private set => totalProductionValue = value;
    }

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
        int i = 0;
        while (i < undeadChildren.Length) {
            totalProductionValue += undeadChildren[i].CalculateTotalProduction();
            i++;
        }

        helperClassRef.libraryRef.totalUndeadProductionText.text = $"Total souls/s: {totalProductionValue}";
        return totalProductionValue;
    }

    public void ResetUndeadChildCountLevel() {
        for (int i = 0; i < undeadChildren.Length; i++) {
            undeadChildren[i].Count = 0;
            undeadChildren[i].Level = 0;
        }
    }
}