using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class EnemyJumper : Enemy, IJumpable
{
    [SerializeField]
    protected float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            Jump();
        }
    }

    public void Jump()
    {
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return !(Mathf.Abs(_rb.velocity.y) > 0.0001f);
    }
}
