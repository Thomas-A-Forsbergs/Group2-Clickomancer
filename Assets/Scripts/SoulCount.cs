using UnityEngine;
using UnityEngine.UI;

public class SoulCount : MonoBehaviour
{
    
    [Header("Drag and Drop reference here")]
    public TMPro.TMP_Text soulText;
    
    [Header("Configurable values")]
    public int souls;
    public int soulsPerClick = 1;
    public int upgradeMultiplier = 0;
    public int upgradeLevel;
    public int upgradeCost;
    public int Souls
    {
        get => PlayerPrefs.GetInt("Souls", 0);
        set => PlayerPrefs.SetInt("Souls", value);
    }
    public void Update()
    {
        soulText.text = "Souls:" + Souls;
    }

    public void Click()
    {
         Souls += soulsPerClick * upgradeMultiplier;
    }
}