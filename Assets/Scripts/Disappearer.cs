using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappearer : MonoBehaviour
{
    [SerializeField] float delayDisappearTime = 1f;
    [SerializeField] float DisappearTime = 1f;
    [SerializeField] float ReappearTime = 1f;
    [SerializeField] SpriteRenderer sr;
    bool inRange = false;
    float timePassed;
    float alpha = 1;
    private void Update()
    {
        if (!inRange)
        {
            Reappear();
            return;
        }
        Disappear();
    }

    private void Reappear()
    {
        if (alpha >= 1) return;
        alpha += Time.deltaTime / ReappearTime;
        sr.color = new Color(1, 1, 1, alpha);
    }

    private void Disappear()
    {
        if (alpha <= 0)
        {
            timePassed = 0;
            return;
        }
        if (timePassed < delayDisappearTime) 
        {
            timePassed += Time.deltaTime;
            return;
        }
        alpha -= Time.deltaTime / DisappearTime;
        sr.color = new Color(1, 1, 1, alpha);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            print("true");
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            print("false");
            inRange = false;
        }
    }
}
