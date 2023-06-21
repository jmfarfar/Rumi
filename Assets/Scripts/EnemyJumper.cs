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
        dir *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            Jump();
        }
        Movement();

        if (hitPoints <= 0)
        {
            DestroyEnemy(gameObject);
        }
    }

    protected override void Movement()
    {
        //Debug.DrawRay(transform.position, dir, Color.red);        

        hitInfo = Physics2D.BoxCastAll(transform.position - new Vector3(0, 0.2f, 0), new Vector2(1.5f, 1), 0f, dir);

        if (hitInfo.Length < 0)
        {
            return;
        }

        foreach (var hit in hitInfo)
        {
            if (hit.collider.tag.Equals(TagManager.PLAYER))
            {
                _isAttacking = true;
                return;
            }

            _isAttacking = false;
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
