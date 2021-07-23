using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHandler : MonoBehaviour, Holdable, IWeapon
{
    [SerializeField] SpriteRenderer playerSprite = null;
    [SerializeField] AnimatorOverrideController animatorOverride = null;

    //used to set animator controller to default, this is probably unncessary and there's a better way but idc
    RuntimeAnimatorController originalAnimator = null;
    Animator playerAnimator;
    Transform playerHand;

    Collider2D pickupableItem;
    SpriteRenderer pickupableItemSprite;

    bool isEquiped = false;
    private void Awake()
    {
        pickupableItem = gameObject.GetComponent<Collider2D>();
        pickupableItemSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    public void Interact(Transform playerHand, Animator playerAnimator)
    {
        //equip stick 
        //Todo: add pickup item animation
        if (!isEquiped)
        {
            this.playerHand = playerHand;
            this.playerAnimator = playerAnimator;

            originalAnimator = playerAnimator.runtimeAnimatorController;

            playerAnimator.runtimeAnimatorController = animatorOverride;
            isEquiped = true;

            pickupableItem.enabled = false;
            pickupableItemSprite.enabled = false;

            //gameObject.transform.SetParent(player.transform);
            //gameObject.transform.localPosition = new Vector3(0.61f, 0, 0);
            //gameObject.layer = LayerMask.NameToLayer("Weapon");
        }

        //drop stick
        //Todo: add drop item exit animation
        else
        {

            gameObject.transform.position = playerHand.position;
            pickupableItem.enabled = true;
            pickupableItemSprite.enabled = true;

            //sets animations back to default
            playerAnimator.runtimeAnimatorController = originalAnimator;
            this.playerAnimator = null;
            this.playerHand = null;

            //    gameObject.transform.SetParent(null);
            //    gameObject.layer = LayerMask.NameToLayer("Interaction");
            //
        }
    }
    //Todo: make weapon do attacking action when method is called
    public void Use()
    {
        
    }
}
