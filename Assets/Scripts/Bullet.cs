using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") return;
            Destroy(gameObject);
    }
    public void IsReflected(Vector2 rotation)
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        rigidBody.velocity = rotation * -speed;
    }
}