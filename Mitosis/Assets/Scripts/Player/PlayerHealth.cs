using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // The maximum health of the player
    public int currentHealth; // The current health of the player
    [SerializeField] EnemyHealth enemyHealth; // Enemy health instance

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(25); // The player takes damage when colliding with the object with the specified name
        }
        else if (other.gameObject.name == "Heart(Clone)")
        {
            HealthIncrease(25); // The player takes heal when colliding with the object with the specified name
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease the current health by the damage amount

        if (currentHealth <= 0)
        {
            Die(); // If the health reaches 0, destroy the enemy
        }
    }
    private void HealthIncrease(int healAmount)
    {
        currentHealth += healAmount; // Increase the current health by the damage amount
        enemyHealth.HeartDie();
    }

    private void Die()
    {
        Destroy(gameObject); // Destroy the enemy object
    }
}
