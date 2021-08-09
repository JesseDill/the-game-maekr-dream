using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject bubble;
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
            print("what");
            SummonBubble();
        }
    }
    private void SummonBubble()
    {
        bubble.SetActive(!bubble.activeSelf);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bubble.activeSelf && collision.gameObject.tag == "Obstacle")
        {
            Vector3 contactLocation = collision.bounds.ClosestPoint(bubble.transform.position);
            Vector3 distanceFromCenterToContact = contactLocation - collision.bounds.center;
            Vector3 normalizedDisplacement = Vector3.Normalize(distanceFromCenterToContact);
            
            collision.GetComponent<Bullet>().IsReflected(new Vector2(normalizedDisplacement.x, normalizedDisplacement.y));
            //Rigidbody2D bulletRB = collision.GetComponent<Rigidbody2D>();
            //bulletRB.transform.right = bulletRB.transform.up;
        }
    }
}
