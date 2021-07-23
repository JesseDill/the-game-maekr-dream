using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Holdable
{
    //Call this method when pressing the F button for interaction 
    void Interact(Transform playerHand, Animator playerAnimator);
   
}
