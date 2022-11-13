using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTeleportBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject tele;
    public GameObject tele2;

    //Moves camera and player to the next area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector3(tele.transform.position.x, tele.transform.position.y, player.transform.position.z);

        //Sets the boundary for the camera
        Cam2Behaviour cb = GameObject.FindObjectOfType<Cam2Behaviour>();
        cb.Position(tele.transform.position.x, tele2.transform.position.y, tele.transform.position.x, tele.transform.position.y);
    }
}
