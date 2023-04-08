using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLineMovement : MonoBehaviour
{
    int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(0, 1);
        direction = randomNumber < 0.5 ? -1 : 1;
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * direction * Time.deltaTime);
        if (transform.position.x >= 8.35)
        {//go to left if at the right edge of screen
            direction = 1;
        }
        else if (transform.position.x <= -8.35)
        {//go to right if at the left edge of screen
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            direction = -1;
        }
    }
}
