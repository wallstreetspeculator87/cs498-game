using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballPileScript : MonoBehaviour
{
    private void PileCollide(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerGlobals = other.GetComponentInChildren<PlayerGlobals>();
            playerGlobals.ammo = playerGlobals.maxAmmo;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PileCollide(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        PileCollide(other);
    }
}
