using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public GameObject thrower;
    public Vector3 direction;
    private Rigidbody rb;
    public const float snowballSpeed = 1750f;
    public const float snowballLifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * snowballSpeed);
        Destroy(gameObject, snowballLifetime);
    }

    // Prefered over Update for rigidbodies
    private void FixedUpdate()
    {
        
    }
    
    private void SnowballCollide(Collider other) 
    {
        if (other.CompareTag("Target"))
        {
            other.GetComponent<TargetScript>().Hit(thrower);
        }
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SnowballCollide(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        //SnowballCollide(other);
    }
}
