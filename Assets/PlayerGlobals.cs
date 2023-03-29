using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGlobals : MonoBehaviour
{
    /*
     * This script just holds variables related to the player which may be useful in several different scripts.
    */

    // 
    public int ammo = 5;
    public int maxAmmo = 5;
    public int hp = 100;
    public int maxHp = 100;

    // Pause character/mouse movement until game starts
    public bool characterEnabled = false;
}
