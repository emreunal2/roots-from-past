using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject mainUI;
    [SerializeField] TextMeshProUGUI[] nameText, descriptionText, debuffDescription;
    [SerializeField] Image[] itemImage;
    [SerializeField] int[] itemIndex;

    public static UpgradeMenu instance;
    void Start()
    {
        instance = this;
        GetUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetUpgrade()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomNumber = UpgradeManager.instance.ChooseRandomCard();
            UpgradeBase Item = UpgradeManager.instance.upgrades[randomNumber];
            nameText[i].text = Item.UpgradeName;
            itemImage[i].sprite = Item.Sprite;
            descriptionText[i].text = Item.Description;
            debuffDescription[i].text = Item.DebuffDescription;
            itemIndex[i] = randomNumber; 
            
        }
       
    }

    public void PickUpgrade(int index)
    {
        UpgradeManager.instance.UseUpgrade(itemIndex[index]);
        Time.timeScale = 1f;
        mainUI.SetActive(true);
        menu.SetActive(false);
    }

    public void OpenUpdateMenu()
    {
        GetUpgrade();
        Time.timeScale = 0f;
        mainUI.SetActive(false);
        menu.SetActive(true);   
    }

}
