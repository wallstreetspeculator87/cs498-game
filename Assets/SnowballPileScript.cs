using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballPileScript : MonoBehaviour
{
    public GameObject player;
    public GameObject pile;
    private float range = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, pile.transform.position);
        if (distance <= range) {
            //player.SendMessage("RefillAmmo");
        }
    }
}
