using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    Collider2D cd;
    [SerializeField] GameObject player;
    bool isEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        cd = gameObject.GetComponent<Collider2D>();
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
        cd.enabled = !cd.isActiveAndEnabled;
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
        }
    }
}
