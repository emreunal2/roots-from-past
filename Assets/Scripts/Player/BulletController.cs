using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float moveSpeed = 10f;
    [SerializeField] float dmg;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        damageUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(dmg);
            collision.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject);
            collision.GetComponent<EnemyMovement>().Speed += 2;
        }
    }

    public void damageUpdate()
    {
        dmg = PlayerStats.instance.Damage;
    }


}
