using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public TMPro.TMP_Text ManaText;
    public float currentMana = 100f;
    public int SpellCost = 80;
    public float MaxMana = 100f;
    public float manaPerSec = 1f;
    float elapsedTime;
    public float manaRegen = 1f;
    private bool IsAffordable => currentMana >= SpellCost;

    public void UseSpell()
    {
        if (!IsAffordable)
        {
            return;
        }

        currentMana -= SpellCost;
    }

    public void Click()
    {
        UseSpell();
    }

    private void Update()
    {
        this.elapsedTime += Time.deltaTime;
        if (this.elapsedTime >= this.manaRegen)
        {
            if (currentMana >= MaxMana)
            {
                currentMana = MaxMana;
                this.elapsedTime -= manaRegen;
                return;
                
            }
            this.currentMana += manaPerSec;
            this.elapsedTime -= manaRegen;
        }
        Display();
    }
    private void Display()
    {
        ManaText.text = "Mana:" + currentMana + "/" + MaxMana;
    }

}
