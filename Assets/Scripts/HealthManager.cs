using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {        
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Rumi is dead");
            gameController.Die();
        }
        gameManager.UpdateHealth(health);
    }

    public void RecoverHealth(float amount)
    {
        health = (health + amount) > maxHealth ? maxHealth : health + amount;
        gameManager.UpdateHealth(health);
    }
}
