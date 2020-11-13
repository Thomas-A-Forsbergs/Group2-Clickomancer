using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class Rebirth : MonoBehaviour
{
    [Header("Drag and Drop reference here")]
    public SoulCount Soulref;
    public Undead Zombieref;
    public TMPro.TMP_Text RebirthText;
    public TMPro.TMP_Text BonusText;
    public int rebirth;
    public float  rebirthModifier = 0f;

    public float modifierFactor = 1f;

    public int Reborn
    {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }

    // Update is called once per frame
    void Update()
    {
        Display();
    }
    // Update is called once per frame
    public void  RebirthButton()
    {
        Reborn++;
        calculateRebirthModifer();
        
    }
    void Start()
    {
        Display();
    }
    private void calculateRebirthModifer()
    {
        int amountofsouls = Soulref.Souls;
        rebirthModifier +=  amountofsouls * modifierFactor;
        Display();
        Soulref.Souls = 0;
        Soulref.UpgradeLevel = 0;
        Zombieref.Count = 0;
        Zombieref.Level = 0;
    }
    
    private void Display()
    {
        RebirthText.text = "Rebirth:" + Reborn;
        BonusText.text = "Bonus:" + rebirthModifier;
    }
}