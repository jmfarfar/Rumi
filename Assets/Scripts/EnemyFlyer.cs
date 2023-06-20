using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyFlyer : Enemy, IFly
{
    private void Update()
    {
        Fly();

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Fly()
    {
        Movement();
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
