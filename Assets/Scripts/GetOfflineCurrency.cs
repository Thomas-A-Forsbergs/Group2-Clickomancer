using System;
using UnityEngine;
using TMPro;

public class GetOfflineCurrency : MonoBehaviour {
    [Header("Drag and Drop references here")]
    private HelperClass helperClassRef;

    public SoulCount soulRef;
    public Undead zombieRef;

    [Header("Text reference for Offline Time")]
    public TextMeshProUGUI offlineTimeText;

    public string offlineTimeTextString;

    [Header("Text reference for Offline Produced Souls text")]
    public TextMeshProUGUI offlineProductionText;

    public string offlineProductionTextString;

    public string OfflineTime {
        get => PlayerPrefs.GetString("SoulsEarnedOffline", "0000-00-00");
        private set => PlayerPrefs.SetString("SoulsEarnedOffline", value);
    }

    public int FirstTimePlaying {
        get => PlayerPrefs.GetInt("FirstTimePlaying", 1);
        private set => PlayerPrefs.SetInt("FirstTimePlaying", value);
    }

    private void Awake() {
        if (FirstTimePlaying != 1) {
            CalculateOfflineProduction();
        }

        FirstTimePlaying = 0;
    }

    private void Start()
    {
        helperClassRef = GetComponentInParent<HelperClass>();
    }

    private void OnApplicationQuit() {
        OfflineTime = DateTime.Now.ToString();
    }

    private void CalculateOfflineProduction() {
        var currentTime = DateTime.Now;
        var offlineTime = Convert.ToDateTime(OfflineTime);
        var interval = currentTime - offlineTime;

        double totalProduction = zombieRef.CalculateTotalProduction();

        double totalOfflineProduction = (int) interval.TotalSeconds * totalProduction;

        double amountOfSouls = helperClassRef.StringToDouble(soulRef.Souls);
        double totalAmountOfSouls = helperClassRef.StringToDouble(soulRef.TotalSoulsOwned);

        var tempSoulDouble = amountOfSouls + totalOfflineProduction;
        var tempTotalDouble = totalAmountOfSouls + totalOfflineProduction;

        helperClassRef.DoubleToString(tempSoulDouble, "Souls");
        helperClassRef.DoubleToString(tempTotalDouble, "TotalSoulsOwned");

        offlineTimeText.text =
            $"{offlineTimeTextString} {interval.Days}d, {interval.Hours}h, {interval.Minutes}m, {interval.Seconds}s!";
        offlineProductionText.text = $"{offlineProductionTextString} {totalOfflineProduction}!";
    }
}