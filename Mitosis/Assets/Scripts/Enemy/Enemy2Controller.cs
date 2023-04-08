using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet; // bullet to spawn when attacked
    [SerializeField] public float delay;
    private bool canAttack = true; //true when the attack delay is over


    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {//spawns 2 attacks that go to different directions
            Instantiate(enemyBullet, transform.position, Quaternion.Euler(0f, 0f, 45f));
            Instantiate(enemyBullet, transform.position, Quaternion.Euler(0f, 0f, -45f));
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
