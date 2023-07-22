using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int hitPoints;
    [SerializeField]
    private Animator animatorFX;

    protected Vector2 dir = new Vector2(8, 0);
    protected RaycastHit2D[] hitInfo;
    protected Rigidbody2D _rb;

    protected bool _isAttacking;

    protected virtual void Movement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        //Debug.DrawRay(transform.position, dir, Color.red);


        hitInfo = Physics2D.BoxCastAll(transform.position - new Vector3(0, 0.2f, 0), new Vector2(1.5f, 2.3f), 0f, dir);

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
        if (collision.gameObject.tag == TagManager.PLAYER && !_isAttacking)
        {
            animator.SetBool("gotHit", true);
            AudioManager.Instance.PlaySFX("Sfx_Hit");
            TakeDamage(1);
        }
    }

    protected void OnCollisionExit2D(Collision2D collision)
    {
        animatorFX.SetBool("gotHit", false);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - new Vector3(0, 0.2f, 0), new Vector3(1.5f, 2.3f, 1));
    }

    protected IEnumerator DelayDeath(GameObject obj)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(obj);
    }

    protected void DestroyEnemy(GameObject obj)
    {
        StartCoroutine(DelayDeath(obj));
    }
}
