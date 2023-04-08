using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100; // The maximum health of the enemy
    int currentHealth; // The current health of the enemy
    [SerializeField] GameObject clonePrefab; // Same prefab as the enemy

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
        currentHealth = maxHealth;// Reset health

        // Instantiate a copy of the prefab at the spawner's position and rotation
        GameObject clone = Instantiate(clonePrefab, transform.position, transform.rotation);
        clone.GetComponent<EnemyLineMovement>().direction = GetComponent<EnemyLineMovement>().direction * -1;
    }
}
