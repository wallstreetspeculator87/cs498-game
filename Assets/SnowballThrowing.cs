using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballThrowing : MonoBehaviour
{
    private GameObject player;
    public GameObject snowballPrefab;
    private PlayerGlobals playerGlobals;
    private Transform playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.gameObject;
        playerGlobals = GetComponent<PlayerGlobals>();
        playerCamera = transform.Find("Camera");
    }

    IEnumerator throwSnowball()
    {
        playerGlobals.snowballEnabled = false;
        --playerGlobals.ammo;
        var snowball = Instantiate(snowballPrefab,
            player.transform.position + (playerCamera.forward * 2.0f), Quaternion.identity, player.transform.parent
        );
        snowball.GetComponent<SnowballScript>().thrower = player;
        snowball.GetComponent<SnowballScript>().direction = playerCamera.forward;

        yield return new WaitForSecondsRealtime(playerGlobals.snowballCooldown);
        playerGlobals.snowballEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerGlobals.characterEnabled && playerGlobals.snowballEnabled
            && playerGlobals.ammo > 0 && Input.GetMouseButton(0))
        {
            StartCoroutine(throwSnowball());
        }
    }
}
