using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movementVector;
    CapsuleCollider2D capsuleCollider2D;
    Rigidbody2D rb;

    public float movementSpeed = 6f;
    public float jumpHeight = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("SoulSand")))
        {
            movementSpeed = 4f;
            jumpHeight = 12f;           
        }
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ice")))
        {
            movementSpeed = 13f;
            jumpHeight = 20f;
        }
        if (capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            movementSpeed = 6f;
            jumpHeight = 15f;
        }
    }
    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }
    private void OnJump(InputValue value)
    {
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) && !capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ice")) && !capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("SoulSand")))
        {
            return; 
        }
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpHeight);
        }
    }
}