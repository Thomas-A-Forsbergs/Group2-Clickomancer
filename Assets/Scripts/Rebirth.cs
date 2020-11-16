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
    public HelperClass _helperClassRef;
    public SoulCount Soulref;
    public Undead Zombieref;
 
    public TMPro.TMP_Text RebirthText;
    public TMPro.TMP_Text BonusText;
    public int rebirth;
    //public float  rebirthModifier = 0f;

    public double modifierFactor = 1f;

    public int rebirthThreshold = 0;
    
    
    
    
    public int Reborn
    {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }
    
    public string RebirthModifier
    {
        get => PlayerPrefs.GetString("RebirthModifier", "0");
        set => PlayerPrefs.SetString("RebirthModifier", value);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        Display();
    }
    // Update is called once per frame
    public void  RebirthButton()
    {
        calculateRebirthModifer();
    }
    void Start()
    {
        Display();
    }
    private void calculateRebirthModifer()
    {
        double amountofsouls = _helperClassRef.StringToDouble(Soulref.TotalSoulsOwned);
        if (rebirthThreshold < amountofsouls )
        {
            Reborn++;
            double modToAdd =  amountofsouls * modifierFactor;
            double currentMod = _helperClassRef.StringToDouble(RebirthModifier);
            double totalModToAdd = currentMod + modToAdd;
            _helperClassRef.DoubleToString(totalModToAdd, "RebirthModifier");
            Display();
            _helperClassRef.DoubleToString(0, "Souls");
            _helperClassRef.DoubleToString(0, "TotalSoulsOwned");
            Soulref.UpgradeLevel = 0;
            Zombieref.Count = 0;
            Zombieref.Level = 0;
        }
    }
    
    private void Display()
    {
        RebirthText.text = "Rebirth:" + Reborn;
        Debug.Log("Bonus: " + RebirthModifier);
        BonusText.text = "Bonus:" + RebirthModifier;
    }
}