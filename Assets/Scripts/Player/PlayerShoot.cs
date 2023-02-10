using System.Linq;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;
    public Transform[] enemies;
    public GameObject projectile;
    public float shootDelay;
    public float range;
    public LayerMask layerMask;

    private float shootTimer;

    private void Awake()
    {
        instance = this;
        shootTimer = shootDelay;
    }

    private void Start()
    {
        UpdateShootStats();
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
            enemies = new Transform[colliders.Length];
            for (int i=0; i<colliders.Length;i++)
            {
                enemies[i] = colliders[i].transform;
            }

            Transform closestEnemy = FindClosestEnemy();
            if (closestEnemy != null)
            {
                Shoot(closestEnemy);
                shootTimer = shootDelay;
            }
        }
    }

    private Transform FindClosestEnemy()
    {
        float minDistance = float.MaxValue;
        Transform closestEnemy = null;

        foreach (Transform enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void Shoot(Transform target)
    {
        AudioManager.instance.PlaySFX(0);
        Vector2 direction = (target.position - transform.position).normalized;
        GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.GetComponent<Rigidbody2D>().velocity = direction * newProjectile.GetComponent<BulletController>().MoveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void UpdateShootStats()
    {
        range = PlayerStats.instance.ShootRange;
        shootDelay = 10/PlayerStats.instance.AttackSpeed;
    }
}
