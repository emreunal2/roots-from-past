using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    [SerializeField] float xpAmount;
    [SerializeField] float moveSpeed;
    [SerializeField] bool isPickedUp;

    public float XpAmount { get => xpAmount; set => xpAmount = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    void Update()
    {
        if(isPickedUp)
        {
            Vector3 direction = (PlayerStats.instance.transform.position - transform.position).normalized;
            transform.position += moveSpeed * Time.deltaTime * direction;
        }
    }

    public void PickUp()
    {
        if (!isPickedUp)
        {
            isPickedUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {       
            collision.GetComponent<LevelSystem>().GainXP(XpAmount);
            Destroy(gameObject);
        }
    }
}
