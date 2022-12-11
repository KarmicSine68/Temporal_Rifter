using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTeleportBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject tele;

    public GameObject min;
    public GameObject max;

    public bool fifteen;
    public bool twenty;
    public bool twentyFive;
    public bool thirty;
    public bool fortyFive;
    public bool sixty;
    public bool seventyFive;

    int time;

    bool enemy;

    private void Start()
    {
        if(fifteen)
        {
            time = 15;
        }
        if(twenty)
        {
            time = 20;
        }
        if (twentyFive)
        {
            time = 25;
        }
        if (thirty)
        {
            time = 30;
        }
        if (fortyFive)
        {
            time = 45;
        }
        if (sixty)
        {
            time = 60;
        }
        if (seventyFive)
        {
            time = 75;
        }
    }

    //Moves the player and camera to the next room
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = new Vector3(tele.transform.position.x, tele.transform.position.y, player.transform.position.z);

        //Sets the boundary for the camera
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(min.transform.position.x, min.transform.position.y, max.transform.position.x, max.transform.position.y);

        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.StopTimer();
        StartCoroutine("Delay");

        tb.SetSpawn(tele.transform.position);

        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.StoreTime(time);

        if (enemy)
        {
            Debug.Log("goodbye");
            ChaserBehaviour cs = FindObjectOfType<ChaserBehaviour>();
            cs.Escaped();
            StartCoroutine(NoEnemy());
        }
    }

    public void EnemySpawned()
    {
        Debug.Log("Hello");
        enemy = true;
    }

    IEnumerator NoEnemy()
    {
        yield return new WaitForSeconds(1);
        enemy = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.TimeStart(time);
    }
}
