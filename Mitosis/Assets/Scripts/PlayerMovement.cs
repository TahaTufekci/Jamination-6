using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed; // The speed at which the player moves

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // Gets the player's horizontal input (A or D)

        if (moveInput != 0)
        {
            transform.Translate(Vector2.right * moveInput * speed * Time.deltaTime); // Moves the player left or right
        }
    }
}
