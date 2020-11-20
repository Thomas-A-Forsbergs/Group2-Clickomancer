using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineBoxWindow : MonoBehaviour
{
    private HelperClass helperClassRef;

    public GameObject activateDeactivateTarget;
    public Sprite dennisSprite;
    
    
    
    private void Awake()
    {
        activateDeactivateTarget.SetActive(false);
        
        helperClassRef = GameObject.Find("GameSystem").GetComponent<HelperClass>();
        GetOfflineCurrency offlineCurrencyRef = helperClassRef.GetComponentInChildren<GetOfflineCurrency>();
        var getFirstTimePlaying = offlineCurrencyRef.FirstTimePlaying;
        Debug.Log(getFirstTimePlaying);
        
        if (getFirstTimePlaying == 0)
        {
            DisplayWindow();
        }
    }
    
    void DisplayWindow()
    {
        activateDeactivateTarget.SetActive(true);
    }
    
    public void CloseWindow()
    {
        activateDeactivateTarget.SetActive(false);
    }
}
