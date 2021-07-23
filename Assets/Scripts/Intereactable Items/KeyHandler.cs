using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour, Holdable
{
    Key keyData;
    GateHandler gate;
    private void Awake()
    {
        keyData = gameObject.GetComponent<Key>();
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if collision is a gate and stores the info
        if (collision.tag == "Gate")
        {
            gate = collision.gameObject.GetComponent<GateHandler>(); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //leaving a gate collision removes gate information 
        //NOTE: this code assumes at most only one gate object will be interacting with player at all times
        if (collision.tag == "Gate")
        {
            gate = null;
        }
    }
    public void AttemptUnlockingGate()
    {
        //if the key type for the door and held key is the same
        if (keyData.GetKeyType() == gate.GetKeyType())
        {
            //destroy the key, and open the door
            gate.ChangeGateState();
            Destroy(gameObject);
        }
    }

    public void Interact(Transform playerHand, Animator playerAnimator)
    {
        //pickup key
        if (gameObject.transform.parent == null)
        {
            gameObject.transform.SetParent(playerHand);

        }
        //drop key
        else if (gate == null)
        {
            gameObject.transform.SetParent(null);
        }
        //attempt using key on gate
        else
        {
            AttemptUnlockingGate();
        }

    }

}
