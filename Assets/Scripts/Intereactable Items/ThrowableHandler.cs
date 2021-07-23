using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableHandler : MonoBehaviour, Holdable
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] Camera mainCamera;
    Rigidbody2D rb;
    Vector2 launchDirection;
    Vector3 cursorPosition;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.isKinematic = true;
    }
    private void Update()
    {
        cursorPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void ThrowProjectile()
    {

        rb.isKinematic = false;
        launchDirection = CalculateDirection();
        rb.AddForce(launchDirection * projectileSpeed, ForceMode2D.Impulse);
    }

    private Vector2 CalculateDirection()
    {
        //returns vector between throwable and cursor positions with a magnitude of 1
        return (new Vector2(cursorPosition.x, cursorPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void Interact(Transform playerHand, Animator animator)
    {
        if (gameObject.transform.parent == null)
        {
            gameObject.transform.SetParent(playerHand);

        }
        else
        {
            gameObject.transform.SetParent(null);
            ThrowProjectile();
        }
    }

}
