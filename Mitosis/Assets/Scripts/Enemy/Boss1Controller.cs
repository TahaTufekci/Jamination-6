using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : MonoBehaviour
{
    [SerializeField] float launchSpeed = 5; // The speed that it launches the bullets
    [SerializeField] GameObject bullet;
    Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        StartCoroutine(MainAttack());//start attacking
    }

    IEnumerator MainAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));// Wait for a while
            enemyAnim.Play("enemy4_002Action");
            for (int i = 0; i < Random.Range(8, 16)/*Random amount of bullets*/; i++)
            {
                GameObject instance = Instantiate(bullet, transform.position, Quaternion.identity);//create bullet
                instance.GetComponent<Rigidbody>().velocity = Vector3.up * launchSpeed;//launch it up
            }
        }
        
    }
}
