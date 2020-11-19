using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class GetOfflineCurrency : MonoBehaviour {
    [Header("Drag and Drop references here")]
    private HelperClass helperClassRef;

    // public SoulCount soulRef;
    // public Undead zombieRef;

    [Header("Text reference for Offline Time")]
    public TextMeshProUGUI offlineTimeText;

    public string offlineTimeTextString;

    [Header("Text reference for Offline Produced Souls text")]
    public TextMeshProUGUI offlineProductionText;

    public string offlineProductionTextString;

    private void Awake() {
        helperClassRef = GetComponentInParent<HelperClass>();
 
    }


    public string OfflineTime {
        get => PlayerPrefs.GetString("SoulsEarnedOffline", "0000-00-00");
        private set => PlayerPrefs.SetString("SoulsEarnedOffline", value);
    }

    public int FirstTimePlaying {
        get => PlayerPrefs.GetInt("FirstTimePlaying", 1);
        private set => PlayerPrefs.SetInt("FirstTimePlaying", value);
    }
    
    
    private void Start()
    {
        if (FirstTimePlaying == 0) {
            CalculateOfflineProduction();
        }
    }

    private void OnApplicationQuit()
    {
        FirstTimePlaying = 0;
        OfflineTime = DateTime.Now.ToString();
    }

    private void CalculateOfflineProduction() {
        var currentTime = DateTime.Now;
        var offlineTime = Convert.ToDateTime(OfflineTime);
        var interval = currentTime - offlineTime;
        
        double totalProduction = helperClassRef.undeadRef.CalculateTotalUndeadProduction();
        //Debug.Log(helperClassRef.undeadRef.CalculateTotalUndeadProduction());
        
        double totalOfflineProduction = (int) interval.TotalSeconds * totalProduction;

        double amountOfSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.Souls);
        double totalAmountOfSouls = helperClassRef.StringToDouble(helperClassRef.soulRef.TotalSoulsOwned);

        var tempSoulDouble = amountOfSouls + totalOfflineProduction;
        var tempTotalDouble = totalAmountOfSouls + totalOfflineProduction;

        helperClassRef.DoubleToString(tempSoulDouble, "Souls");
        helperClassRef.DoubleToString(tempTotalDouble, "TotalSoulsOwned");

        offlineTimeText.text =
            $"{offlineTimeTextString} {interval.Days}d, {interval.Hours}h, {interval.Minutes}m, {interval.Seconds}s!";
        offlineProductionText.text = $"{offlineProductionTextString} {totalOfflineProduction}!";
    }
}