using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] GameObject shield;
    [SerializeField] bool isInvulnerable;
    [SerializeField] bool isShieldBroken;

    [SerializeField] float shieldMaxCooldown;
    private float cooldown;

    public bool IsInvulnerable { get => isInvulnerable; set => isInvulnerable = value; }
    public float ShieldMaxCooldown { get => shieldMaxCooldown; set => shieldMaxCooldown = value; }

    void Start()
    {
        
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
}
