using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime); // Moves the object down

        // If the object goes off the screen, destroy it immediately
        if (transform.position.y < Camera.main.orthographicSize)
        {
            Destroy(gameObject,1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
