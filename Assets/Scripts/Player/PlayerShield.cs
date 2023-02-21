using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] bool isInvulnerable;
    [SerializeField] bool isShieldBroken;
    [SerializeField] ShieldUpgrade firstshieldupgrade;
    [SerializeField] ShieldUpgrade shieldupgrade;

    [SerializeField] float shieldMaxCooldown;
    private float cooldown;

    public bool IsInvulnerable { get => isInvulnerable; set => isInvulnerable = value; }
    public float ShieldMaxCooldown { get => shieldMaxCooldown; set => shieldMaxCooldown = value; }

    void Start()
    {
        firstshieldupgrade.onEvent.AddListener(LowerCooldown);
        shieldupgrade.onEvent.AddListener(BasicUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        if (isShieldBroken)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                ActivateShield();
            }
        }
    }

    public void DisableShield()
    {
        shield.SetActive(false);
        isInvulnerable = false;
        cooldown = ShieldMaxCooldown;
        isShieldBroken = true;
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
        isInvulnerable = true;
        isShieldBroken = false;
    }

    public void LowerCooldown() 
    {
        ActivateShield();
        UpgradeManager.instance.upgrades.Remove(firstshieldupgrade);
        UpgradeManager.instance.AddFromList(firstshieldupgrade.NextUpgrades);
        firstshieldupgrade.onEvent.RemoveListener(LowerCooldown);
    }

    public void BasicUpgrade()
    {
        ShieldMaxCooldown -= 3;
    }
}
