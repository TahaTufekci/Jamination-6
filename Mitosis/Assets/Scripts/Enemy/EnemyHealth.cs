using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // The maximum health of the enemy
    public int currentHealth; // The current health of the enemy

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerBullet(Clone)")
        {
            TakeDamage(25); // The enemy takes damage when colliding with the object with the specified name
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

    private void Die()
    {
        Destroy(gameObject); // Destroy the enemy object
    }
}
