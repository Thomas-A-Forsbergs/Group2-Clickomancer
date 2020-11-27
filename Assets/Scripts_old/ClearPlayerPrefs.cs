using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    public void ResetButton() 
    {
        PlayerPrefs.DeleteAll();
    }
}
