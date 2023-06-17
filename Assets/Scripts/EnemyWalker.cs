using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class EnemyWalker : Enemy, ICharacter
{
    private void Start()
    {
        dir = new Vector2(8, 0);
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        Debug.DrawRay(transform.position, dir, Color.red);

        // TODO: Improve this process to detect the player with a Raycast and increments velocity
        hitInfo = Physics2D.RaycastAll(transform.position, dir, 8f);

        if (hitInfo.Length < 0)
        {
            return;
        }

        foreach (var hit in hitInfo)
        {
            Debug.Log("Enter to not null collider");
            Debug.Log($"Value of Collider: {hit.collider} || Value of Tag: {hit.collider.tag}");
            if (hit.collider.tag.Equals(TagManager.PLAYER))
            {
                Debug.Log("Player Detected");
                speed = speed < 0f ? -10f : 10f;
                return;
            }

            speed = speed < 0f ? -5f : 5f;

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
