using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float horizontalMovement, verticalMovement;
    public BoxCollider2D bounds;
    [SerializeField] Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
      
    }

    private void FixedUpdate()
    {
        Movement();
        anim.SetFloat("Speed", Mathf.Max(Mathf.Abs(rb.velocity.x), Mathf.Abs(rb.velocity.y)));
    }

    private void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, bounds.bounds.min.x, bounds.bounds.max.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bounds.bounds.min.y, bounds.bounds.max.y);
        transform.position = clampedPosition;
    }

    private void Movement()
    {
        rb.velocity = new Vector2(horizontalMovement, verticalMovement).normalized * PlayerStats.instance.MoveSpeed;
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    void CheckInput()
    {
       horizontalMovement = Input.GetAxisRaw("Horizontal");
       verticalMovement = Input.GetAxisRaw("Vertical");
    }
}
