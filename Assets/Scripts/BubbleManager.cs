using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject Player;
    bool isEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SummonBubble();
        }
    }
    private void SummonBubble()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Vector3 contactLocation = collision.bounds.ClosestPoint(gameObject.transform.position);
            Vector3 distanceFromCenterToContact = contactLocation - collision.bounds.center;
            Vector3 normalizedDisplacement = Vector3.Normalize(distanceFromCenterToContact);
            
            collision.GetComponent<Bullet>().IsReflected(new Vector2(normalizedDisplacement.x, normalizedDisplacement.y));
            //Rigidbody2D bulletRB = collision.GetComponent<Rigidbody2D>();
            //bulletRB.transform.right = bulletRB.transform.up;
            print("work");
        }
    }
}
