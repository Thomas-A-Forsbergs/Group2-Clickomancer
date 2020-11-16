using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public TMPro.TMP_Text ManaText;
    public int currentMana = 100;
    public int SpellCost = 80;
    public int MaxMana = 100;
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
        Display();
    } 
    private void Display()
    {
        ManaText.text = "Mana:" + currentMana + "/" + MaxMana;
    }
}


