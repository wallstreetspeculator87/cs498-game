using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public bool beenHit = false;
    public void Hit(GameObject thrower)
    { 
        if (!beenHit)
        {
            Debug.Log("Target hit");
            ++thrower.GetComponent<PlayerGlobals>().targetsHit;
        }
        beenHit = true;
    }
}
