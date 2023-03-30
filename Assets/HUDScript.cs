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
    Label crosshair;
    Label tipLabel;

    bool hitmarkerOn = false;
    float hitmarkerLength = 0.66f;

    bool tipping = false;

    void Start()
    {
        playerGlobals = transform.parent.GetComponent<PlayerGlobals>();
        ui = GetComponent<UIDocument>().rootVisualElement;
        hp = ui.Query<Label>("Health");
        ammo = ui.Query<Label>("Ammo");
        crosshair = ui.Query<Label>("Crosshair");
        tipLabel = ui.Query<Label>("Tip");
    }

    IEnumerator HitmarkerText()
    {
        hitmarkerOn = true;
        crosshair.text = "- + -";
        yield return new WaitForSecondsRealtime(hitmarkerLength);
        crosshair.text = "+";
        hitmarkerOn = false;
    }

    public void SetHitmarker()
    {
        if (!hitmarkerOn)
        {
            StartCoroutine(HitmarkerText());
        }
    }

    IEnumerator ShowTip(string tip, float tipLength)
    {
        tipping = true;
        tipLabel.text = "[Tip]\n" + tip;
        yield return new WaitForSecondsRealtime(tipLength);
        tipLabel.text = "";
        tipping = false;
    }

    public void SetTip(string tip, float tipLength)
    {
        if (!tipping)
        {
            StartCoroutine(ShowTip(tip, tipLength));
        }
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = "Health: " + playerGlobals.hp + " / " + playerGlobals.maxHp;
        ammo.text = "Snowballs: " + playerGlobals.ammo + " / " + playerGlobals.maxAmmo;   
    }
}
