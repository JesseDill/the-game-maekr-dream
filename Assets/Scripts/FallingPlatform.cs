using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] GameObject PhysicsCollider;
    [SerializeField] float waitTime = 2f;
    [SerializeField] float fallTime= 10f;
    BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(Drop());
        }
    }
    public IEnumerator Drop()
    {   //TODO: Add a rumble/effect to notify player platform is about to fall/break
        
        yield return new WaitForSeconds(waitTime);
        //Sends the platform downwards
        StartCoroutine(MovePlatform());
        yield return new WaitForSeconds(5f);
        //disables collider
        PhysicsCollider.SetActive(false);
    }

    IEnumerator MovePlatform()
    {

        float elapsedTime = 0;
        while (elapsedTime < fallTime)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, transform.position.y -30, transform.position.z),
                elapsedTime/fallTime);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
