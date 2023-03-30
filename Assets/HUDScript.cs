using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUDScript : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerGlobals playerGlobals;
    VisualElement ui;
    Label hp;
    Label ammo;

    void Start()
    {
        playerGlobals = transform.parent.GetComponent<PlayerGlobals>();
        ui = GetComponent<UIDocument>().rootVisualElement;
        hp = ui.Query<Label>("Health");
        ammo = ui.Query<Label>("Ammo");
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "Health: " + playerGlobals.hp + " / " + playerGlobals.maxHp;
        ammo.text = "Snowballs: " + playerGlobals.ammo + " / " + playerGlobals.maxAmmo;   
    }
}
