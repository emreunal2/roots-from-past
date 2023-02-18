using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    [SerializeField] float maxHp;
    [SerializeField] float currentHp;
    [SerializeField] float hpRecovery;

    [SerializeField] float moveSpeed;
    [SerializeField] float attackSpeed;
    [SerializeField] float shootRange;

    [SerializeField] float ammoNumber;
    [SerializeField] float revival;
    [SerializeField] float magnet;

    [SerializeField] float damage;
    [SerializeField] float critChange;
    private float recoveryCD = 1;

    [SerializeField] bool isInvulnerable;
    [SerializeField] float shieldCooldown, shieldMaxCooldown;


    [SerializeField] float damageCooldown, maxDamageCooldown;

    [SerializeField] GameObject shield;

    public float MaxHp { get => maxHp; set => maxHp = value; }
    public float CurrentHp { get => currentHp; set => currentHp = value; }
    public float HpRecovery { get => hpRecovery; set => hpRecovery = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float AmmoNumber { get => ammoNumber; set => ammoNumber = value; }
    public float Revival { get => revival; set => revival = value; }
    public float Magnet { get => magnet; set => magnet = value; }
    public float Damage { get => damage; set => damage = value; }
    public float CritChange { get => critChange; set => critChange = value; }
    public float ShootRange { get => shootRange; set => shootRange = value; }
    public float DamageCooldown { get => damageCooldown; set => damageCooldown = value; }
    public float MaxDamageCooldown { get => maxDamageCooldown; set => maxDamageCooldown = value; }
    public float ShieldCooldown { get => shieldCooldown; set => shieldCooldown = value; }
    public float ShieldMaxCooldown { get => shieldMaxCooldown; set => shieldMaxCooldown = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        recoveryCD -= Time.deltaTime; 
        damageCooldown -= Time.deltaTime;
        if (recoveryCD < 0)
        {
            RecoverHP(hpRecovery);
            recoveryCD = 1;
        }
    }

    public void TakeDamage(float amount)
    {
        if (isInvulnerable)
        {
            isInvulnerable = false;
            shield.SetActive(false);
        }
        else
        {
            CurrentHp -= amount;
            damageCooldown = maxDamageCooldown;
            if (CurrentHp <= 0)
            {
                if (Revival > 0)
                {
                    Revival--;
                    CurrentHp = (float)(MaxHp * 0.25);
                }
                else
                {
                    Die();
                }
            }
        }
    }
    
    //TO-DO die mechanic
    public void Die()
    {
        SceneManager.LoadScene("GameOver");
        AudioManager.instance.PlayMusic(0);
    }

    public void GainXP(float amount)
    {

    }

    public void RecoverHP(float amount)
    {
        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
