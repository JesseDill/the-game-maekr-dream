using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerHand;
    [SerializeField] GameObject interactionCollider;

    //object within player vicinity to  be interacted with
    public GameObject interactableObject;

    //an object that is in use is only a holdable object
    GameObject itemInUse = null;
    Animator playerAnimator = null;

    bool isHoldingItem = false;

    private void Awake()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            interactableObject = collision.gameObject;
        }


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == interactableObject)
        {
            interactableObject = null;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }
    }

    private void Interact()
    {
        //If player is holding an object, interact with it and assume it will be dropped/or disposed of 
        if (itemInUse != null)
        {
            itemInUse.GetComponent<Holdable>().Interact(gameObject.transform, playerAnimator);
            interactionCollider.SetActive(true);
            itemInUse = null;
        }

        //If player can interact with an object, interact with it
        else if (interactableObject != null)
        {
            if (interactableObject.GetComponent<Holdable>() != null)
            {
                interactableObject.GetComponent<Holdable>().Interact(gameObject.transform, playerAnimator);
                interactionCollider.SetActive(false);
                itemInUse = interactableObject;
            }
            else if (interactableObject.GetComponent<Interactable>() != null)
            {
                interactableObject.GetComponent<Interactable>().Interact();
            }
        }
    }

    //if (itemInUse == null && interactableObjects == null) return;

    ////checks if player can pick up an item
    //if(itemInUse == null && interactableObjects != null)
    //{
    //    foreach (GameObject item in interactableObjects)
    //    {
    //        if (item.tag != "Key" && item.tag != "Throwable") continue;
    //        itemInUse = item;
    //        EquipInHand();
    //        return;
    //    }
    //}

    //if (itemInUse.tag == "Key")
    //{
    //    foreach (GameObject item in interactableObjects)
    //    {
    //        if (item.tag == "Gate")
    //        {
    //            //Key keyToCheck = itemInUse.GetComponent<Key>();
    //            GateHandler gateToCheck = item.GetComponent<GateHandler>();
    //            keyHandler.CheckKeyTypes(itemInUse, gateToCheck);
    //            return;
    //        }
    //    }
    //}
    //else if (itemInUse.tag == "Throwable")
    //{
    //    ThrowableHandler throwableHandler = itemInUse.GetComponent<ThrowableHandler>();
    //    throwableHandler.ThrowProjectile();
    //}

    ////drops current item in hand 
    //DropItem();
    //itemInUse = null;

    //private void DropItem()
    //{
    //    itemInUse.transform.parent = null;
    //}

    //private void EquipInHand()
    //{
    //    //puts item in players hand
    //    itemInUse.transform.parent = playerHand;
    //    itemInUse.transform.position = playerHand.position;
    //}
}
