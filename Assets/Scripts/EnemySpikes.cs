using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpikes : Enemy
{

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
        transform.Translate(0, speed * Time.deltaTime, 0);
    }    

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        base.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER))
        {
            TakeDamage(1);
        }
    }

    protected override void OnDrawGizmos()
    {
        
    }
}
