using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TipScript : MonoBehaviour
{
    public string tip = "Welcome to Snowball Game. You can move around with the WASD keys and look around by moving your mouse.";
    public float tipLength = 10f;
    public bool tipped = false;

    private void TipCollide(Collider other)
    {
        if (!tipped && other.CompareTag("Player"))
        {
            //tipped = true;
            other.GetComponentInChildren<HUDScript>().SetTip(tip, tipLength);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        TipCollide(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        TipCollide(other);
    }
}
