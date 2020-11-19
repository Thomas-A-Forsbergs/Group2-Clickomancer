using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PopUpBox : MonoBehaviour
{
    public GameObject popUpText;
    public void Start()
    {
        popUpText.SetActive(false);
    }

    public void OnMouseOver()
    {
        popUpText.SetActive(true);
    }

    public void OnMouseExit()
    {
        popUpText.SetActive(false);
    }
}