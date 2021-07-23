using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    // [SerializeField] float targetRange = 10f;
    [SerializeField] Shooter shooter;
    [SerializeField] float fireRatePerSecond = 2f;
    [SerializeField] bool targetsPlayer = true;
    Transform player;
    float lastTimeFired = Mathf.Infinity;
    bool inRange = false;

    //private void Awake()
    //{
      //  combat = GetComponent<Combat>();
    //}

    private void Update()
    {
        if (!inRange) return;
        CheckIfShoot();

        lastTimeFired += Time.deltaTime;
    }

    private void CheckIfShoot()
    {
        if (lastTimeFired < 1f / fireRatePerSecond) return;
        
        if (targetsPlayer == true)
            shooter.ShootTarget(player);
        else
            shooter.ShootStraight();
            
        lastTimeFired = 0;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player = collider.transform;
            inRange = true; 
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            inRange = false;
        }
    }
}
