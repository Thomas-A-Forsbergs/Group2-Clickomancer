using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaMeter : MonoBehaviour
{
    private Image meterImage;

    private void Awake()
    {
        meterImage = transform.Find("meter").GetComponent<Image>();

        meterImage.fillAmount = .3f;
    }
}
