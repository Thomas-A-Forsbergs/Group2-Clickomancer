// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.Serialization;

using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour {
    // public TMPro.TMP_Text ManaText;
    public HelperClass helperClassRef;
    public float currentMana = 100f;
    public int spellCost = 80;
    public float maxMana = 100f;
    public float manaPerSec = 1f;
    float elapsedTime;
    public float manaRegen = 1f;
    [SerializeField] private Image meterImage;
    private bool IsAffordable => currentMana >= spellCost;

    public void UseSpell() {
        if (!IsAffordable) {
            return;
        }

        currentMana -= spellCost;
    }

    public void Click() {
        UseSpell();
        // Debug.Log((currentMana - maxMana) / 100);
        // meterImage.fillAmount = maxMana - currentMana / 100;
    }

    private void Update() {
        meterImage.fillAmount = currentMana / maxMana;
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.manaRegen) {
            if (currentMana >= maxMana) {
                currentMana = maxMana;
                this.elapsedTime -= manaRegen;
                return;
            }

            this.currentMana += manaPerSec;
            this.elapsedTime -= manaRegen;
        }

        Display();
    }

    private void Display() {
        helperClassRef.libraryRef.manaText.text = "Mana:" + currentMana + "/" + maxMana;
    }
}