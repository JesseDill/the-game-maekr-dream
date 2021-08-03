using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem dust;

    [Header("Layer Masks")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask cornerCorrectLayer;

    [Header("Movement Variables")]
    [SerializeField] float movementAcceleration = 50f;
    [SerializeField] float maxMoveSpeed = 12f;
    [SerializeField] float groundLinearDrag = 10f;
    float horizInputDirection;
    bool changingDirection => (rb.velocity.x > 0f && horizInputDirection < 0f) || (rb.velocity.x < 0f && horizInputDirection > 0f);
    bool facingRight = true;

    [Header("Jump Variables")]
    [SerializeField] float jumpForce = 500f;
    [SerializeField] float airLinearDrag = 2.5f;
    [SerializeField] float fallGravity = 8f;
    [SerializeField] float lowJumpGravity = 5f;
    [SerializeField] float coyoteTime = 0.1f;
    [SerializeField] float jumpBufferLength = 0.1f;
    float coyoteTimeCounter;
    float jumpBufferCounter;
    bool canJump => jumpBufferCounter > 0f && coyoteTimeCounter > 0f;

    [Header("Ground Collision Variables")]
    // [SerializeField] float groundRaycastLength;
    // [SerializeField] Vector3 groundRaycastOffset;
    [SerializeField] float groundCheckRadius = 0.2f;
    bool onGround;

    [Header("Corner Correction Variables")]
    [SerializeField] float topRaycastLength;
    [SerializeField] Vector3 edgeRaycastOffset;
    [SerializeField] Vector3 innerRaycastOffset;
    bool canCornerCorrect;


    // Update is called once per frame
    void Update()
    {
        horizInputDirection = GetInput().x;
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferLength;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }


        //Animation
        anim.SetBool("isGrounded", onGround);
        anim.SetFloat("horizontalDirection", Mathf.Abs(horizInputDirection));
        if (horizInputDirection < 0f && facingRight)
            FlipSprite();
        else if (horizInputDirection > 0f && !facingRight)
            FlipSprite();
        if (rb.velocity.y < -0.1f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    // Best for code involving physics
    void FixedUpdate()
    {
        CollisionCheck();
        MoveCharacter();
        if (onGround)
        {
            ApplyGroundLinearDrag();
            coyoteTimeCounter = coyoteTime;

            // Animation
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        else
        {
            ApplyAirLinearDrag();
            ApplyGravMultiplier();
            coyoteTimeCounter -= Time.fixedDeltaTime;
        }

        if (canJump)
            Jump();

        if (canCornerCorrect)
            CornerCorrect(rb.velocity.y);
    }

    static Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void MoveCharacter()
    {
        rb.AddForce(new Vector2(horizInputDirection, 0f) * movementAcceleration);

        if (Math.Abs(rb.velocity.x) > maxMoveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxMoveSpeed, rb.velocity.y);
    }

    void ApplyGroundLinearDrag()
    {
        if (Math.Abs(horizInputDirection) < 0.4f || changingDirection)
            rb.drag = groundLinearDrag;
        else
            rb.drag = 0f;
    }

    void ApplyAirLinearDrag()
    {
        rb.drag = airLinearDrag;
    }

    void Jump()
    {
        CreateDust();
        ApplyAirLinearDrag();
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce);
        coyoteTimeCounter = 0f;
        jumpBufferCounter = 0f;

        // Animation
        anim.SetBool("isJumping", true);
        anim.SetBool("isFalling", false);
    }

    void ApplyGravMultiplier()
    {
        if (rb.velocity.y < 0)
            rb.gravityScale = fallGravity;

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.gravityScale = lowJumpGravity;

        else
            rb.gravityScale = 2f;
    }

    void CollisionCheck()
    {
        // Ground Collisions
        // onGround = Physics2D.Raycast(transform.position, Vector2.down, groundRaycastLength, groundLayer)
        //        || Physics2D.Raycast(transform.position - groundRaycastOffset, Vector2.down, groundRaycastLength, groundLayer)
        //        || Physics2D.Raycast(transform.position + groundRaycastOffset, Vector2.down, groundRaycastLength, groundLayer);
        onGround = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                onGround = true;
        }

        // Corner Collisions
        canCornerCorrect = Physics2D.Raycast(transform.position + edgeRaycastOffset, Vector2.up, topRaycastLength, cornerCorrectLayer) &&
                           !Physics2D.Raycast(transform.position + innerRaycastOffset, Vector2.up, topRaycastLength, cornerCorrectLayer) ||
                           Physics2D.Raycast(transform.position - edgeRaycastOffset, Vector2.up, topRaycastLength, cornerCorrectLayer) &&
                           !Physics2D.Raycast(transform.position - innerRaycastOffset, Vector2.up, topRaycastLength, cornerCorrectLayer);
    }

    // I DONT KNOW HOW THIS WORKS
    void CornerCorrect(float yVelocity)
    {
        // Push player to the right
        RaycastHit2D hit = Physics2D.Raycast(transform.position - innerRaycastOffset + Vector3.up * topRaycastLength, Vector3.left, topRaycastLength, cornerCorrectLayer);
        if (hit.collider != null)
        {
            float correctDist = Vector3.Distance(new Vector3(hit.point.x, transform.position.y, 0f) + Vector3.up * topRaycastLength,
                transform.position - edgeRaycastOffset + Vector3.up * topRaycastLength);
            transform.position = new Vector3(transform.position.x + correctDist, transform.position.y, transform.position.z);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
            return;
        }

        // Push player to the left
        hit = Physics2D.Raycast(transform.position + innerRaycastOffset + Vector3.up * topRaycastLength, Vector3.right, topRaycastLength, cornerCorrectLayer);
        if (hit.collider != null)
        {
            float correctDist = Vector3.Distance(new Vector3(hit.point.x, transform.position.y, 0f) + Vector3.up * topRaycastLength,
                transform.position + edgeRaycastOffset + Vector3.up * topRaycastLength);
            transform.position = new Vector3(transform.position.x - correctDist, transform.position.y, transform.position.z);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
            return;
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        if (onGround)
            CreateDust();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Ground Check
        // Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundRaycastLength);
        // Gizmos.DrawLine(transform.position - groundRaycastOffset, transform.position - groundRaycastOffset + Vector3.down * groundRaycastLength);
        // Gizmos.DrawLine(transform.position + groundRaycastOffset, transform.position + groundRaycastOffset + Vector3.down * groundRaycastLength);

        // Corner Check
        Gizmos.DrawLine(transform.position + edgeRaycastOffset, transform.position + edgeRaycastOffset + Vector3.up * topRaycastLength);
        Gizmos.DrawLine(transform.position - edgeRaycastOffset, transform.position - edgeRaycastOffset + Vector3.up * topRaycastLength);
        Gizmos.DrawLine(transform.position + innerRaycastOffset, transform.position + innerRaycastOffset + Vector3.up * topRaycastLength);
        Gizmos.DrawLine(transform.position - innerRaycastOffset, transform.position - innerRaycastOffset + Vector3.up * topRaycastLength);

        // Corner Distance Check
        Gizmos.DrawLine(transform.position - innerRaycastOffset + Vector3.up * topRaycastLength,
                        transform.position - innerRaycastOffset + Vector3.up * topRaycastLength + Vector3.left * topRaycastLength);
        Gizmos.DrawLine(transform.position + innerRaycastOffset + Vector3.up * topRaycastLength,
                        transform.position + innerRaycastOffset + Vector3.up * topRaycastLength + Vector3.right * topRaycastLength);

    }

    void CreateDust()
    {
        dust.Play();
    }
}
