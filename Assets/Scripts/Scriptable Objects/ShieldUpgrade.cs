using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class ShieldUpgrade : UpgradeBase
{
    [SerializeField] bool firstShield;
    [SerializeField] UpgradeBase nextUpgrade;
    
    public override void Apply()
    {
        if (firstShield)
        {
            PlayerStats.instance.GetComponent<PlayerShield>().ActivateShield();
            UpgradeManager.instance.upgrades.Remove(this);
            UpgradeManager.instance.upgrades.Add(nextUpgrade);
        }
        else
        {
            PlayerStats.instance.GetComponent<PlayerShield>().ShieldMaxCooldown -= 3;
        }
    }
}
