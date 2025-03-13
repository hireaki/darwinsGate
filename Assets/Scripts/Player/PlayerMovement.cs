using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;
    private bool jumpButtonHeld;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Update()
    {
        if (!enabled) return;

        float keyboardInput = Input.GetAxisRaw("Horizontal");
        if (keyboardInput != 0) input = keyboardInput;
        else if (!isMovingLeft && !isMovingRight) input = 0;

        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // Keyboard Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if ((Input.GetButton("Jump") || jumpButtonHeld) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump") || !jumpButtonHeld)
        {
            isJumping = false;
        }

    }

    void FixedUpdate()
    {
        if (!enabled) return;
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
    }

    public void MoveLeft()
    {
        isMovingLeft = true;
        input = -1;
    }

    public void MoveRight()
    {
        isMovingRight = true;
        input = 1;
    }

    public void StopMove()
    {
        isMovingLeft = false;
        isMovingRight = false;
        input = 0;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    public void StartJump()
    {
        jumpButtonHeld = true;
        if (isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }

    public void StopJump()
    {
        jumpButtonHeld = false;
        isJumping = false;
        jumpTimeCounter = 0;
    }
    
}
