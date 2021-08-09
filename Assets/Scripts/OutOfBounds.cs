using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    Death deathHandler;
    ReloadScene sceneLoader;
    private void Awake()
    {
        sceneLoader = GetComponent<ReloadScene>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("wtf");
            collision.gameObject.GetComponent<Death>().KillPlayer();
            sceneLoader.DelayedRestart(.5f);
        }
    }
}
