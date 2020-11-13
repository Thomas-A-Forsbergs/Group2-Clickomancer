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
    public float  rebirthmodifer = 1;

    public int Reborn
    {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }

    // Update is called once per frame
    void Update()
    {
        RebirthText.text = "Rebirth:" + Reborn;
        BonusText.text = "Bonus:" + rebirthmodifer;
        
    }
    // Update is called once per frame
    public void  RebirthButton()
    {
        Reborn++;
        calculateRebirthModifer();
        
    }
    
    private void calculateRebirthModifer()
    {
        int amountofsouls = Soulref.Souls;
        rebirthmodifer += amountofsouls * 1;
        Soulref.Souls = 0;
        Soulref.UpgradeLevel = 0;
        Zombieref.Count = 0;
        Zombieref.Level = 0;
    }
}