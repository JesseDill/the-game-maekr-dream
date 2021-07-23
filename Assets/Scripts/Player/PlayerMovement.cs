using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public Rigidbody2D playerRB;
    public Animator animator;
    Death death;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool crouch = false;
    bool jump = false;
    bool shortJump = false;

    private void Awake()
    {
        death = GetComponent<Death>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonUp("Jump") && playerRB.velocity.y > 0)
        {
            shortJump = true;
        }

        if (Input.GetButtonDown("Crouch")) 
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        jump = false;
        shortJump = false;
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    // FixedUpdate is recommended for RigidBody objects with physics
    void FixedUpdate()
    {
        if (!death.GetIsDead())//checks if player is dead or not first before enabling movement
                               //disables movement if player is dead
        {
            // Move our character
            controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, shortJump);
        }
        
    }
}
