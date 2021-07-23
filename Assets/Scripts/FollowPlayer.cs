using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowPlayer : MonoBehaviour
{
    //for testing purposes
    [SerializeField] Transform player;
    [SerializeField] GameObject deathWall;
    CinemachineBrain brain;

    private void Awake()
    {
        brain = GetComponent<CinemachineBrain>();
    }
    private void Start()
    {
        deathWall.SetActive(false);
        brain.enabled = false;
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
