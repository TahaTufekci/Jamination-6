using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyLineMovement : MonoBehaviour
{
    int direction; //direction of movement, left or righ (1 or -1)
    [SerializeField] float speed; //movement speed
    void Start()
    {
        switch (Random.Range(1,3))//random direction at start
        {
            case 1:
                direction = 1;
                break;
            case 2:
                direction = -1;
                break;

            default:
                break;
        }
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
