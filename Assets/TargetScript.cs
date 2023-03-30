using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TargetScript : MonoBehaviour
{
    public bool beenHit = false;
    public void Hit(GameObject thrower)
    { 
        beenHit = true;
        Debug.Log("Target hit");
        ++thrower.GetComponent<PlayerGlobals>().targetsHit;
        thrower.transform.Find("HUD").GetComponent<HUDScript>().SetHitmarker();
    }
}
