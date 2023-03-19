using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWeapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float shootDelay, shootTimer;
    [SerializeField] int ammoSize;
    [SerializeField] WeaponUpgrade ammoNumberUpgrade;
     
    // Start is called before the first frame update
    void Start()
    {
        shootTimer = shootDelay;
        UpdateHWStats();
        UpgradeManager.instance.OnPick.AddListener(UpdateHWStats);
        ammoNumberUpgrade.OnEvent.AddListener(AmmoNumberUpgrade);
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            StartCoroutine(Shoot());
            shootTimer = shootDelay;
        }
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < ammoSize; i++)
        {
            Vector2 direction = new Vector2(transform.parent.localScale.x, 0f);
            GameObject newProjectile = Instantiate(bullet, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = direction * newProjectile.GetComponent<BulletController>().MoveSpeed;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void UpdateHWStats()
    {
        shootDelay = 30 / PlayerStats.instance.AttackSpeed;
    }

    public void AmmoNumberUpgrade()
    {
        ammoSize++;
    }
}
