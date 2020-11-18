using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindow : MonoBehaviour
{
    private HelperClass helperClassRef;

    public GameObject activateDeactivateTarget;
    public Sprite dennisSprite;
    
    
    
    private void Awake()
    {
        activateDeactivateTarget.SetActive(false);
        
        helperClassRef = GameObject.Find("GameSystem").GetComponent<HelperClass>();
        GetOfflineCurrency offlineCurrencyRef = helperClassRef.GetComponentInChildren<GetOfflineCurrency>();
        if (offlineCurrencyRef.FirstTimePlaying != 1)
        {
            return;
        }
        DisplayWindow();
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
