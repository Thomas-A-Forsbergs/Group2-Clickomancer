using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;

public class Rebirth : MonoBehaviour
{
    [Header("Drag and Drop reference here")]
    public TMPro.TMP_Text RebirthText;
    public TMPro.TMP_Text BonusText;
    public int rebirth;
    

    
    
    public int Reborn
    {
        get => PlayerPrefs.GetInt("Rebirth", 0);
        set => PlayerPrefs.SetInt("Rebirth", value);
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RebirthText.text = "Rebirth:" + Reborn;
    }
    // Update is called once per frame
    public void  RebirthButton()
    {
        Reborn++;
    }
}