using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All Iweapons are also holdables
public interface IWeapon
{
    //Call this method when pressing something like mouse button for attacking/shooting action, 
    //playerhand and animator should already be stored since Interact method from holdable interface should be called before Use method 
    void Use();
}
