using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;

    public bool vertical;
    public bool horizontal;

    public GameObject player;

    float speed;

    Vector2 nextPos;

    bool touch;

    private void Start()
    {
        touch = false;

        speed = 15;

        nextPos = waypoint1.transform.position;
    }

    // Moves the platform
    void Update()
    {
        if (vertical)
        {
            if (transform.position.y >= waypoint1.transform.position.y)
            {
                nextPos = waypoint2.transform.position;
            }
            else if (transform.position.y <= waypoint2.transform.position.y)
            {
                nextPos = waypoint1.transform.position;
            }
        }

        if (horizontal)
        {
            if (transform.position.x <= waypoint1.transform.position.x)
            {
                nextPos = waypoint2.transform.position;
            }
            else if (transform.position.x >= waypoint2.transform.position.x)
            {
                nextPos = waypoint1.transform.position;
            }

            if (touch)
            {
                player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Enemy 2")
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}

