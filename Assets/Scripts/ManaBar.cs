// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.Serialization;

using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private HelperClass helperClassRef;
    [Header("Configurable values")] public double soulsPerClick = 1;

    public float currentMana = 100f;
    public int spellCost = 20;
    public float spell1;
    public float maxMana = 100f;
    public float manaPerSec = 1f;
    float elapsedTime;
    public float manaRegen = 1f;
    [SerializeField] private Image meterImage;
    private bool IsAffordable => currentMana >= spellCost;

    private void Awake()
    {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    private void Update()
    {
        meterImage.fillAmount = currentMana / maxMana;
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.manaRegen)
        {
            if (currentMana >= maxMana)
            {
                currentMana = maxMana;
                this.elapsedTime -= manaRegen;
                return;
            }

            this.currentMana += manaPerSec;
            this.elapsedTime -= manaRegen;
        }

        Display();
    }

    public void SpellRemoveMana()
    {
        if (!IsAffordable)
        {
            return;
        }

        currentMana -= spellCost;
        spell2();
    }

    public void spell2()
    {
        helperClassRef.soulRef.Click();
        helperClassRef.soulRef.Click();
    }

    public void SpellButton() {
        SpellRemoveMana();
        // Debug.Log((currentMana - maxMana) / 100);
        // meterImage.fillAmount = maxMana - currentMana / 100;
    }

    private void Display() {
        helperClassRef.libraryRef.manaText.text = "Mana:" + currentMana + "/" + maxMana;
    }
}