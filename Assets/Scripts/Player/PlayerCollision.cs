using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public CharacterController2D controller;
    public Death death;

    public void OnCollisionEnter2D(Collision2D collisionInfo)
    {

        if (collisionInfo.collider.tag == "Obstacle")
        {

            /* 
             * No longer needed because this is handeled by Death.cs script
             * 
             * Sets run speed to 0 and disables CharacterController2D
             * Fixes a problem where after character runs into obstacle,
             * the player loses control but the character keeps going in the
             * last recorded direction instead of stopping. 
             */

            movement.runSpeed = 0f;
            controller.enabled = false;
            death.KillPlayer();
        }
    }
}
