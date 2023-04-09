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
    [SerializeField] GameObject heartPrefab;
    private GameObject heart; // Heart that the player can pick up
    [SerializeField] bool isBoss; // Checks if the enemy is a boss, if it is a boss, instead of splitting on death it spawns new enemies
    Score scoreScript;
    HealthBar healthBar;
    [SerializeField] AudioSource audioS; // Main audio source
    [SerializeField] AudioClip damageEnemy,enemyDie,bossDie;

    private void Start()
    {
        currentHealth = maxHealth; // Set the initial health to the maximum health
        scoreScript = GameObject.Find("Script").GetComponent<Score>();
        healthBar = gameObject.GetComponent<HealthBar>();
        audioS = GameObject.Find("Audio").GetComponent<AudioSource>();
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
        if (healthBar != null)//healthbar effect
        {
            healthBar.Damage(currentHealth, damage, maxHealth);
        }
        currentHealth -= damage; // Decrease the current health by the damage amount

        //Spawn blood effect
        GameObject spawnedEffect = Instantiate(blood, transform.position, Quaternion.identity);
        Destroy(spawnedEffect, 1.5f);

        audioS.PlayOneShot(damageEnemy);
        Debug.Log(audioS);

        if (currentHealth <= 0)
        {
            Die(); // If the health reaches 0, destroy the enemy
        }

        
    }

    private void Die()
    {
        if (isBoss)
        {
            currentHealth = 99999;
            audioS.PlayOneShot(bossDie);
            scoreScript.score += 2000;
            scoreScript.ScoreChange();
            StartCoroutine(BossDeath());
        }
        else
        {
            currentHealth = maxHealth;// Reset health
            healthBar.greenhealth.fillAmount = 1;
            audioS.PlayOneShot(enemyDie);

            scoreScript.score += 250;
            scoreScript.ScoreChange();
            // Instantiate a copy of the prefab at the spawner's position and rotation
            GameObject clone = Instantiate(clonePrefab, transform.position, transform.rotation);
            clone.GetComponent<EnemyLineMovement>().direction = GetComponent<EnemyLineMovement>().direction * -1;

            // Decrease size
            transform.localScale = new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z / 1.5f);
            clone.transform.localScale = transform.localScale;
            
            // Heart goes down to the player for health with a chance of 25%
            float randomNumber = Random.Range(0f, 1f);
            if (randomNumber <= 0.25f)
            {
                heart = Instantiate(heartPrefab,new Vector3(transform.position.x,2.5f,transform.position.z), Quaternion.identity);
            }
        }
        
    }
    IEnumerator BossDeath()
    {
        GetComponent<EnemyLineMovement>().stopMovement = true;
        transform.Find("BossDeath1").gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        GameObject spawned1 = Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(transform.position.x,4,transform.position.z), Quaternion.Euler(0, -180, 90));
        GameObject spawned2 = Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector3(transform.position.x,2.5f,transform.position.z), Quaternion.Euler(0, -180, 90));
        heart = Instantiate(heartPrefab,new Vector3(transform.position.x,2.5f,transform.position.z), Quaternion.identity);
        spawned1.GetComponent<EnemyLineMovement>().direction = -1;
        spawned2.GetComponent<EnemyLineMovement>().direction = 1;
        Destroy(gameObject);
    }
    public void HeartDie()
    {
        Destroy(GameObject.FindWithTag("Heart"));// Destroy the heart object
    }
}
