using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    GameObject[] enemies;
    [SerializeField] GameObject[] bosses;
    [SerializeField] ParticleSystem bossEffect;
    bool bossSpawning;// True if the boss is spawning
    [SerializeField] AudioSource audioS; // Main audio source
    [SerializeField] AudioClip bossSpawn;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length>5&& !bossSpawning)
        {
            bossSpawning = true;
            StartCoroutine(SpawnBoss());
        }
    }
    private IEnumerator SpawnBoss()
    {
        foreach (GameObject enemy in enemies)
        {
            StartCoroutine(EnemyMove(enemy));
        }
        bossEffect.gameObject.SetActive(true);
        bossEffect.Play();
        StartCoroutine(BossEffectSize());
        audioS.PlayOneShot(bossSpawn);
        yield return new WaitForSeconds(3);
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        Instantiate(bosses[Random.Range(0, bosses.Length)], new Vector3(0, 3, 0), Quaternion.Euler(0,-180,90));
        bossSpawning = false;
        bossEffect.Stop();
    }
    IEnumerator EnemyMove(GameObject enemy)
    {
        // Move each enemy to the target position gradually over time
        enemy.GetComponent<EnemyLineMovement>().stopMovement = true;
        Vector3 startPosition = enemy.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1)
        {
            enemy.transform.position = Vector3.Lerp(startPosition, new Vector3(0, 3, 0), elapsedTime / 1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        enemy.transform.position = new Vector3(0, 3, 0); // Set the final position to ensure accuracy

    }
    IEnumerator BossEffectSize()
    {//Increase the scale of boss effect over time
        float elapsedTime = 0f;

        while (elapsedTime < 3)
        {
            bossEffect.gameObject.transform.localScale = new Vector3(elapsedTime/6, elapsedTime / 6, elapsedTime / 6);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        bossEffect.gameObject.transform.localScale = new Vector3(2, 2, 2); // Set the final size to ensure accuracy
        yield return new WaitForSeconds(3);
        bossEffect.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);// Change the scale back after 3 seconds
    }
}
