using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Control : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet; // bullet to spawn when attacked
    Animator enemyAnim;
    [SerializeField] public float delay;
    private bool canAttack = true; //true when the attack delay is over

    private void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
            enemyAnim.Play("enemy1_001Action");
            enemyAnim.Play("enemy3_001Action");
            StartCoroutine(AttackDelay());
        }
    }
    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(delay);
        canAttack = true;
    }
}
