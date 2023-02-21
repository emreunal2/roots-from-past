using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeDamage : MonoBehaviour
{
    [SerializeField] float dmg;
    [SerializeField] WeaponUpgrade damageUpUpgrade;
    [SerializeField] WeaponUpgrade scaleUpUpgrade;
    // Start is called before the first frame update
    void Start()
    {
        damageUpUpgrade.OnEvent.AddListener(DamageUpgrade);
        scaleUpUpgrade.OnEvent.AddListener(ScaleUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(dmg);
        }
    }



    public void DamageUpgrade()
    {
        dmg += dmg * damageUpUpgrade.Amount / 100;
    }

    public void ScaleUpgrade()
    {
        transform.localScale *= 1.5f;
    }
}
