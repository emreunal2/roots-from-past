using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] Slider hpSlider, xpSlider;
    [SerializeField] int playerLevel;
    [SerializeField] TextMeshProUGUI levelText, timer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLevel = LevelSystem.instance.PlayerLevel;
        hpSlider.maxValue = PlayerStats.instance.MaxHp;
        hpSlider.value = PlayerStats.instance.CurrentHp;

        xpSlider.maxValue = LevelSystem.instance.NeededXP[playerLevel];
        xpSlider.value = LevelSystem.instance.CurrentXP;

        levelText.text = "Level: " + playerLevel;
    }
}
