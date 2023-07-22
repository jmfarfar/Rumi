using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    protected override void Movement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.LIMIT))
        {
            speed *= -1f;
        }        
    }

    protected override void OnDrawGizmos()
    {

    }
}
