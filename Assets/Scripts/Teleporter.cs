using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    ReloadScene sceneLoader;
    private void Awake()
    {
        sceneLoader = GetComponent<ReloadScene>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            sceneLoader.DelayedNext(.5f);
        }
    }
}
