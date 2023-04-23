using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    private PlayerGlobals playerGlobals;

    // Start is called before the first frame update
    void Start()
    {
        playerGlobals = transform.parent.GetComponent<PlayerGlobals>();
    }

    public void Lock()
    {
        playerGlobals.characterEnabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Unlock()
    {
        playerGlobals.characterEnabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerGlobals.characterEnabled)
        {
            return;
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape) && playerGlobals.characterEnabled)
        {
            Unlock();
            transform.parent.GetComponentInChildren<MainMenu>().Show(true);
        }
    }
}
