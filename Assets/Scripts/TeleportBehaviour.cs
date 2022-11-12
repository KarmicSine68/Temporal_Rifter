using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    public GameObject marker1;
    public GameObject marker2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        gc.Teleport();
        Debug.Log("Player teleported");

        Cam2Behaviour c2 = GameObject.FindObjectOfType<Cam2Behaviour>();
        c2.Position(marker1.transform.position.x, marker1.transform.position.y, marker2.transform.position.x, marker2.transform.position.y);
    }
}
