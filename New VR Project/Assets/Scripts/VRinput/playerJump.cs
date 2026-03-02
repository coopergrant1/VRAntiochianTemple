using UnityEngine;
using UnityEngine.InputSystem;

public class playerJump : MonoBehaviour
{
    [SerializeField] private InputActionProperty jumpButton;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private CharacterController cc;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckDistance = 0.1f;
    
    private float gravity = Physics.gravity.y;
    private Vector3 movement;
    private void Update()
    {
        bool _isGround = IsGrounded();

        if (jumpButton.action.WasPressedThisFrame() && _isGround)
        {
            Jump();
        }
        // Apply gravity
        movement.y += gravity * Time.deltaTime;
        // Move the player
        cc.Move(movement * Time.deltaTime);
    }

    private bool IsGrounded()
    {
        // Check using character controller
        return cc.isGrounded;
    }

    private void Jump()
    {
         movement.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
    }
}
