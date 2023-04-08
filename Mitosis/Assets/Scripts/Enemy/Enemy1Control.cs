using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Control : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet; // bullet to spawn when clicked
    [SerializeField] public float delay;
    private bool canAttack = true; //true when the attack delay is over


    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.identity);
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
