using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    public UnityEvent onDeathEvent;
    public Animator animator;
    bool isDead = false;

    private void Update()
    {
        //button to kill player
        if (Input.GetKeyDown(KeyCode.R))
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {   
        //any actions involving death can be added through inspector as methods
        onDeathEvent.Invoke();
        isDead = true;
        animator.SetBool("HasDied", isDead);
    }

    //access this method whenever script wants to know if player is dead
    public bool GetIsDead() 
    {
        return isDead;
    }
}
