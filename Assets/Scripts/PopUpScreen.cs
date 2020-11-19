using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScreen : MonoBehaviour {
    public GameObject popUpBox;
    private bool _showingPopUp;

    public void ToggleScreen()
    {
        if (_showingPopUp)
        {
            Show();
        }
        else
        {
            Hide();
        }

        _showingPopUp = !_showingPopUp;
    }
    private void Show()
    {
        popUpBox.SetActive(true);
    }

    private void Hide()
    {
        popUpBox.SetActive(false);
    }
}