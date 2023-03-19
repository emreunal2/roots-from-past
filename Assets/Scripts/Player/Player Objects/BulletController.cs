using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float dmg;
    [SerializeField] float baseDamage;
    private Rigidbody2D rb;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DamageUpdate();
    }


    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().TakeDamage(dmg);
            Destroy(gameObject);
            collision.GetComponent<EnemyMovement>().Speed += 1.5f;
        }
    }

    public void DamageUpdate()
    {
        dmg = PlayerStats.instance.Damage * baseDamage;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
