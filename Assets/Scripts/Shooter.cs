using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firePoint;
    
    public virtual void ShootTarget(Transform target) {}

    public virtual void ShootStraight() {}

    public float CalculateAngle(Vector3 end, Vector3 start)
    {
        float xPos = end.x - start.x;
        float yPos = end.y - start.y;
        return Mathf.Atan2(yPos, xPos) * Mathf.Rad2Deg;
    }
}
