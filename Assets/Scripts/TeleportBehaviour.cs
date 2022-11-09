using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    public GameObject marker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        gc.Teleport();
        Debug.Log("Player teleported");

        Cam2Behaviour c2 = GameObject.FindObjectOfType<Cam2Behaviour>();
        c2.Position(marker.transform.position.x);
    }
}
