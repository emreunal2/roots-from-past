using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    public List<UpgradeBase> upgrades;
    void Awake()
    {
        instance = this;
    }

    public void UseUpgrade(int upgrade)
    {
        upgrades[upgrade].Apply();
        AudioManager.instance.PlaySFX(3);
        XPPickup.instance.UpdateMagnet();
        PlayerShoot.instance.UpdateShootStats();
    }

    public int ChooseRandomCard()
    {
        int randomNumber = UnityEngine.Random.Range(0, UpgradeManager.instance.upgrades.Count);
        Debug.Log(UpgradeManager.instance.upgrades.Count);
        return randomNumber;
    }
}
