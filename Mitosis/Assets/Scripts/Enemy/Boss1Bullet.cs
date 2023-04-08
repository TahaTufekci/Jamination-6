using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Bullet : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f; // The rotation speed of the object


    private void Start()
    {
        Destroy(gameObject, 10); // Destroy the bullet
    }
    private void Update()
    {
        // Rotate the object around its z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject, 0.01f);
        }
    }
    
}
