using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] GameObject xpPrefab;

    public float Hp { get => hp; set => hp = value; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        Hp -= amount;
        GetComponent<SpriteRenderer>().color = Color.red;
        if (hp <= 0)
        {
            AudioManager.instance.PlaySFX(1);
            Destroy(gameObject);
            Instantiate(xpPrefab, transform.position, transform.rotation);
        }
    }
}
