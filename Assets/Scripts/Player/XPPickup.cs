using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPickup : MonoBehaviour
{
    public static XPPickup instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateMagnet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<XPManager>(out XPManager XPManager))
        {
            collision.GetComponent<XPManager>().PickUp();
            AudioManager.instance.PlaySFX(2);
        }

    }

    public void UpdateMagnet()
    {
        GetComponent<CircleCollider2D>().radius = PlayerStats.instance.Magnet;
    }
}
