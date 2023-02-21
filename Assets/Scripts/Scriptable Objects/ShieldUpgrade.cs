using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class ShieldUpgrade : UpgradeBase
{
    [SerializeField] bool firstShield;
    [SerializeField] List<UpgradeBase> nextUpgrades;
    public UnityEvent onEvent;

    public bool FirstShield { get => firstShield; set => firstShield = value; }
    public List<UpgradeBase> NextUpgrades { get => nextUpgrades; set => nextUpgrades = value; }

    public override void Apply()
    {
        //if (firstShield)
        //{
        onEvent?.Invoke();
            //PlayerStats.instance.GetComponent<PlayerShield>().ActivateShield();
            //UpgradeManager.instance.upgrades.Remove(this);
            //UpgradeManager.instance.AddFromList(nextUpgrades);
        //}
        //else
        //{
            //onEvent.Invoke();
        //}
    }
}
