using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); // Moves the object up

        // If the object goes off the screen, destroy it immediately
        if (transform.position.y > Camera.main.orthographicSize)
        {
            Destroy(gameObject,1f);
        }
    }
}
