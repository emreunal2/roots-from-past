using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed = 5f;

    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else transform.localScale = Vector3.one;
        transform.position += direction * speed * Time.deltaTime;
    }
}
