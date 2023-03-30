using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float playerSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundedCheck;
    public float groundDistance = 0.6f;
    public LayerMask groundMask;

    Vector3 playerVelocity;
    bool isGrounded;

    private PlayerGlobals playerGlobals;

    // Start is called before the first frame update
    void Start()
    {
        playerGlobals = GetComponent<PlayerGlobals>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerGlobals.characterEnabled)
        {
            return;
        }

        isGrounded = Physics.CheckSphere(groundedCheck.position, groundDistance, groundMask);

        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
        }

        float playerX = Input.GetAxis("Horizontal");
        float playerZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * playerX + transform.forward * playerZ;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
