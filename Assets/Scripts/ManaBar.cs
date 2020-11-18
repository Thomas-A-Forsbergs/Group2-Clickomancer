// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.Serialization;

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    private HelperClass helperClassRef;
    [Header("Configurable values")] public double soulsPerClick = 1;

    public float currentMana = 100f;
    public int spellCost1 = 20;
    public int spellCost2 = 20;
    public int spellCost3 = 20;
    public int spellCost4 = 20;
    public int spellCost5 = 20;
    public float maxMana = 100f;
    public float manaPerSec = 1f;
    float elapsedTime;
    public float manaRegen = 1f;
    [SerializeField] private Image meterImage;
    private bool IsAffordable1 => currentMana >= spellCost1;
    private bool IsAffordable2 => currentMana >= spellCost2;
    private bool IsAffordable3 => currentMana >= spellCost3;
    private bool IsAffordable4 => currentMana >= spellCost4;
    private bool IsAffordable5 => currentMana >= spellCost5;

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
    
    private void Display() {
        helperClassRef.libraryRef.manaText.text = "Mana:" + currentMana + "/" + maxMana;
    }
    
    public void SpellRemoveMana1()
    {
        if (!IsAffordable1)
        {
            return;
        }

        currentMana -= spellCost1;
        spell1();

    }
    
    public void SpellRemoveMana2()
    {
        if (!IsAffordable2)
        {
            return;
        }

        currentMana -= spellCost1;
        spell2();
    }

    public void SpellRemoveMana3()
    {
        if (!IsAffordable3)
        {
            return;
        }

        currentMana -= spellCost1;
        spell3();
    }
    
    public void SpellRemoveMana4()
    {
        if (!IsAffordable4)
        {
            return;
        }

        currentMana -= spellCost1;
        spell4();
    }
    
    public void SpellRemoveMana5()
    {
        if (!IsAffordable5)
        {
            return;
        }

        currentMana -= spellCost1;
        spell5();
    }
    
    public void spell1()
    {
        double tempSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
        double tempTotalSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.TotalSoulsOwned);
        double tempvalue = helperClassRef.undeadRef.CalculateTotalUndeadProduction();
        double totalvalue = tempvalue * 30;
        tempSouls += totalvalue;
        tempTotalSouls += totalvalue;
        helperClassRef.DoubleToString(tempSouls, "Souls");
        helperClassRef.DoubleToString(tempTotalSouls, "TotalSoulsOwned");
    }
    
    public void spell2()
    {
        
        StartCoroutine(magicFingers());

    }

    private IEnumerator magicFingers()
    {
        while (currentMana > 6)
        {
            currentMana -= 6;
            helperClassRef.soulRef.Click();
            yield return new WaitForSeconds(5);  
        }
    }
    
    public void spell3()
    {
        helperClassRef.soulRef.Click();
        helperClassRef.soulRef.Click();
    }
    
    public void spell4()
    {
        helperClassRef.soulRef.Click();
        helperClassRef.soulRef.Click();
    }
    
    public void spell5()
    {
        helperClassRef.soulRef.Click();
        helperClassRef.soulRef.Click();
    }

    public void SpellButton1() {
        SpellRemoveMana1();
    }
    
    public void SpellButton2() {
        SpellRemoveMana2();
    }

    public void SpellButton3() {
        SpellRemoveMana3();
    }
    
    public void SpellButton4() {
        SpellRemoveMana4();

    }
    
    public void SpellButton5() {
        SpellRemoveMana5();
    }
}