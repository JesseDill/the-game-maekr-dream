using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] ParticleSystem deathPS;
    [SerializeField] Transform spawnPoint;

    bool hasDied;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle") && !hasDied)
        {
            Die();
        }
    }

    void Die()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        deathPS.Play();
        Invoke("Respawn", 1);
        hasDied = true;
    }

    void Respawn()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;

        player.transform.position = spawnPoint.position;
        player.SetActive(true);
        hasDied = false;
    }
}