using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    public List<UpgradeBase> upgrades;
    [SerializeField] UnityEvent onPick;

    public UnityEvent OnPick { get => onPick; set => onPick = value; }

    void Awake()
    {
        instance = this;
    }

    public void UseUpgrade(int upgrade)
    {
        upgrades[upgrade].Apply();
        AudioManager.instance.PlaySFX(3);
        XPPickup.instance.UpdateMagnet();
        //PlayerShoot.instance.UpdateShootStats();
        onPick.Invoke();
    }

    public int ChooseRandomCard()
    {
        int randomNumber = UnityEngine.Random.Range(0, UpgradeManager.instance.upgrades.Count);
        Debug.Log(UpgradeManager.instance.upgrades.Count);
        return randomNumber;
    }

    public void AddFromList(List<UpgradeBase> upgradesList)
    {
        foreach(UpgradeBase i in upgradesList)
        {
            upgrades.Add(i);
        }
    }
}
