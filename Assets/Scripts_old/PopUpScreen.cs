using UnityEngine;

public class PopUpScreen : MonoBehaviour {
    public GameObject popUpBox;
    private bool _showingPopUp = false;

    public void ToggleScreen() {
        if (!_showingPopUp) {
            Show();
            _showingPopUp = !_showingPopUp;
        } else {
            Hide();
            _showingPopUp = !_showingPopUp;
        }
    }

    private void Show() {
        popUpBox.SetActive(true);
    }

    private void Hide() {
        popUpBox.SetActive(false);
    }
}