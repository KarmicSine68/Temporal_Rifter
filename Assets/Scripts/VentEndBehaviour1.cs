using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentEndBehaviour1 : MonoBehaviour
{
    public GameObject min;
    public GameObject max;
    public GameObject spawnpoint;

    public int time;

    //Sets camera boundary values and sets the player's spawnpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(min.transform.position.x, min.transform.position.y, max.transform.position.x, max.transform.position.y);

        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.SetSpawn(spawnpoint.transform.position.x, spawnpoint.transform.position.y);

        gc.SetTime(25);
    }
}
