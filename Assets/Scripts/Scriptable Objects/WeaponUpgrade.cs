using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Powerups/AOE")]
public class WeaponUpgrade : UpgradeBase
{
    [SerializeField] bool isFirstUpgrade;
    [SerializeField] List<UpgradeBase> addUpgrades;
    [SerializeField] GameObject weapon;
    [SerializeField] UnityEvent onEvent;
    [SerializeField] float amount;

    public UnityEvent OnEvent { get => onEvent; set => onEvent = value; }
    public float Amount { get => amount; set => amount = value; }
    public List<UpgradeBase> AddUpgrades { get => addUpgrades; set => addUpgrades = value; }

    public override void Apply()
    {
        if (isFirstUpgrade) 
        {
            Instantiate(weapon, PlayerStats.instance.transform);
            UpgradeManager.instance.upgrades.Remove(this);
            UpgradeManager.instance.AddFromList(AddUpgrades);
        }
        OnEvent?.Invoke();
    }

}
