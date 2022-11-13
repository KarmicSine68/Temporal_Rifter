using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointBehaviour : MonoBehaviour
{
    //Sets the spawn of the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewGameController gc = GameObject.FindObjectOfType<NewGameController>();
        gc.SetSpawn(transform.position.x, transform.position.y);
    }
}
