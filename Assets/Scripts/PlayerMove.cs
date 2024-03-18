using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    public float SpeedMove = 12f;
    public float gravity = -9.81f; // Standard gravity value
    private CharacterController controller;
    private Vector3 velocity; // Player's current velocity

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get input from joystick
        Vector3 moveDirection = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply movement
        controller.Move((moveDirection * SpeedMove + velocity) * Time.deltaTime);

        // Reset vertical velocity if player is grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
}
