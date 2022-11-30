using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // The markers that the enemy moves between
    public GameObject waypoint1;
    public GameObject waypoint2;

    // The enemy
    GameObject enemy;

    // Spawnpoint of the enemy
    public GameObject enemySpawn;

    Rigidbody2D rb2D;

    float move;

    // Ensures that the enemy starts in the same spot
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;

        transform.position = enemySpawn.transform.position;
        move = 10;
    }

    // Moves the enemy
    private void Update()
    {
        if(transform.position.x <= waypoint1.transform.position.x)
        {
            Debug.Log("Waypoint1 triggered");
            move = 10;
        }
        if(transform.position.x >= waypoint2.transform.position.x)
        {
            Debug.Log("Waypoint2 triggered");
            move = -10;
        }

        rb2D.velocity = new Vector2(move, rb2D.velocity.y);
    }

    // Resets the enemy to its spawnpoint when the player gets captured
    public void EnemyReset()
    {
        transform.position = enemySpawn.transform.position;
    }
}
