using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100; // The maximum health of the enemy
    int currentHealth; // The current health of the enemy
    [SerializeField] GameObject clonePrefab; // Same prefab as the enemy
    [SerializeField] GameObject blood; // Blood effect
    [SerializeField] GameObject[] enemies; // Enemies that can be spawned after a boss' death
    [SerializeField] bool isBoss; // Checks if the enemy is a boss, if it is a boss, instead of splitting on death it spawns new enemies

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

        //Spawn blood effect
        GameObject spawnedEffect = Instantiate(blood,transform.position,Quaternion.identity);
        Destroy(spawnedEffect,1.5f);
    }

    private void Die()
    {
        if (isBoss)
        {
            currentHealth = 99999;
            StartCoroutine(BossDeath());
        }
        else
        {
            currentHealth = maxHealth;// Reset health

            // Instantiate a copy of the prefab at the spawner's position and rotation
            GameObject clone = Instantiate(clonePrefab, transform.position, transform.rotation);
            clone.GetComponent<EnemyLineMovement>().direction = GetComponent<EnemyLineMovement>().direction * -1;

            // Decrease size
            transform.localScale = new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z / 1.5f);
            clone.transform.localScale = transform.localScale;
        }
        
    }
    IEnumerator BossDeath()
    {
        GetComponent<EnemyLineMovement>().stopMovement = true;
        transform.Find("BossDeath1").gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        GameObject spawned1 = Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(transform.position.x,4,transform.position.z), Quaternion.identity);
        GameObject spawned2 = Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(transform.position.x,2.5f,transform.position.z), Quaternion.identity);
        spawned1.GetComponent<EnemyLineMovement>().direction = -1;
        spawned2.GetComponent<EnemyLineMovement>().direction = 1;
        Destroy(gameObject);
    }
}
