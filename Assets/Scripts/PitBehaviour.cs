using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        gc.Respawn();
        Debug.Log("player fell");
    }
}
