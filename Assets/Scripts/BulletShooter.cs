using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : Shooter
{
    public GameObject bulletPrefab;
    [SerializeField] float projectileSpeed = 8f;
    
    public override void ShootTarget(Transform target)
    {
        float angle = CalculateAngle(target.position, firePoint.transform.position);
        firePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        bullet.GetComponent<Bullet>().speed = projectileSpeed;
    }

    public override void ShootStraight()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(transform.right));
    }
}
