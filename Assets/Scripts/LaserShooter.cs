using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShooter : Shooter
{
    // public CircleCollider2D fireRange;
    public LineRenderer lineRenderer;
    RaycastHit2D objectHit;
    int layerMask = (1 << 8) | (1 << 0); // What layers the laser will check for a collision
                                         // Right now it only checks for ground and player
    public override void ShootTarget(Transform target)
    {
        
    }

    public override void ShootStraight()
    {
        objectHit = Physics2D.Raycast(firePoint.position, firePoint.right, Mathf.Infinity, layerMask);

        // a line is not a gameobject and won't kill the player
        // setting a collider on the line won't work, player can stand on the line
        if (objectHit.collider != null)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, objectHit.point);
        } else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        EnableLaser();
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;

        if (objectHit.transform.GetComponent<Death>() != null) // Only player should have a death component
        {
            objectHit.transform.GetComponent<Death>().KillPlayer();
        }
    }
}
