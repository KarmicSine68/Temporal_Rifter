using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTeleportBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject tele;

    public GameObject min;
    public GameObject max;

    //Moves the player and camera to the next room
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = tele.transform.position;

        //Sets the boundary for the camera
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(min.transform.position.x, min.transform.position.y, max.transform.position.x, max.transform.position.y);
    }
}
