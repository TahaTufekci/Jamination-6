using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed; // The speed at which the player moves
    public float delay; //delay amount for shooting
    private bool canAttack = true; //true when the attack delay is over
    [SerializeField] GameObject bullet; // bullet to spawn when clicked
    [SerializeField] Animator playerAnim; // Animator of player
    [SerializeField] AudioSource audioS; // Main audio source
    [SerializeField] AudioClip shoot;

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Gets the player's horizontal input (A or D)

        if (moveInput != 0)
        {
            transform.Translate(Vector2.down * moveInput * speed * Time.deltaTime); // Moves the player left or right
        }
        if (Input.GetMouseButton(0)&&canAttack)
        {
            Instantiate (bullet,transform.position, Quaternion.identity);
            playerAnim.Play("nanobot shoot");
            audioS.PlayOneShot(shoot);
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
