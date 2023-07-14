using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class EnemyWalker : Enemy
{
    [SerializeField] private Animator _anim;
    private void Update()
    {
        Movement();

        if (hitPoints <= 0)
        {
            DestroyEnemy(gameObject);
        }
    }

    protected override void Movement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        //Debug.DrawRay(transform.position, dir, Color.red);

        // TODO: Improve this process to detect the player with a Raycast and increments velocity
        hitInfo = Physics2D.RaycastAll(transform.position, dir, 8f);

        if (hitInfo.Length < 0)
        {
            return;
        }

        foreach (var hit in hitInfo)
        {
            if (hit.collider.tag.Equals(TagManager.PLAYER))
            {
                speed = speed < 0f ? -10f : 10f;
                _isAttacking = true;
                _anim.SetBool("Attacking", true);
                return;
            }

            speed = speed < 0f ? -5f : 5f;
            _isAttacking = false;
            _anim.SetBool("Attacking", false);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
        speed *= -1f;
        dir.x *= -1f;
    }
}
