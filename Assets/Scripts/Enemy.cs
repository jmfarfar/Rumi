using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int hitPoints;

    protected Vector2 dir = new Vector2(8, 0);
    protected RaycastHit2D[] hitInfo;
    protected Rigidbody2D _rb;

    protected bool _isAttacking;
        
    protected virtual void Movement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
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

    protected void TakeDamage(int damage)
    {
        hitPoints--;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter the collision");
        if (collision.gameObject.tag == TagManager.PLAYER && !_isAttacking)
        {
            Debug.Log("Do Damage");
            TakeDamage(1);
        }
    }    

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - new Vector3(0, 0.2f, 0), new Vector3(1.5f, 1, 1));
    }
}
