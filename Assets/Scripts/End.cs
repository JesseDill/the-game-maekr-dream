using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public UnityEvent onGameFinished;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject text;
    [SerializeField] GameObject deathWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            onGameFinished.Invoke();
            FinishGame();
        }
    }

    private void FinishGame()
    {
        audioSource.enabled = true;
        text.GetComponent<Text>().enabled = true;
        deathWall.SetActive(false);
    }
}
