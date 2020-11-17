using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UndeadData : ScriptableObject
{
    [Header("Configurable values")] [SerializeField]
    private string name = "Zombie";
    [SerializeField] public Sprite spriteImage;
    [SerializeField] public int cost = 100;
    public int productionRate = 1;
    
    public int Count {
        get => PlayerPrefs.GetInt("Owned" + name, 0);
        set => PlayerPrefs.SetInt("Owned" + name, value);
    }

    public int Level {
        get => PlayerPrefs.GetInt("Level" + name, 0);
        set => PlayerPrefs.SetInt("Level" + name, value);
    }
}
