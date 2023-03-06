using System;
using UnityEngine;

public class PursuitEnemy : MonoBehaviour
{
    public GameObject player;
    public PursuitBehavior pursuit;

    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        pursuit.target = player.transform;
        pursuit.targetVelocity = playerRb.velocity;
    }
}
