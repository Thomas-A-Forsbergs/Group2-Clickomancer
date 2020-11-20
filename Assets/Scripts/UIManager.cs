using UnityEngine;

public class UIManager : MonoBehaviour {
    public void FullScreenButton() {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ExitApplicationButton() {
        Application.Quit();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}