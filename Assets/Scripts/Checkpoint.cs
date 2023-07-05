using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameController gameController;
    public Transform respawnPoint;

    private SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    // private Collider2D coll;// Para que solo se pueda activar una vez el checkpoint.

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<GameController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        // coll = GetComponentInChildren<Collider2D>();// Para que solo se pueda activar una vez el checkpoint.
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            // coll.enabled = false;// Para que solo se pueda activar una vez el checkpoint.
        }
    }
}