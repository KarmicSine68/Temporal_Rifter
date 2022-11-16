using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewGameController : MonoBehaviour
{
    public GameObject player;

    float spawnX;
    float spawnY;

    int lives;
    public bool end;
    public bool win;
    bool lose;

    public bool died;

    public TMP_Text lifeText;

    int store;

    // Sets the amount of player lives
    void Start()
    {
        lives = 5;
        end = false;
        win = false;

        died = false;
        lose = false;
    }

    // Ends the game when the player runs out of lives
    void Update()
    {
        if (lives < 0)
        {
            lose = true;
            GameOver();
        }
        else
        {
            if (!end && !win)
            {
                lifeText.text = "Lives: " + lives.ToString();
            }
        }
    }

    //Sets the spawnpoint location
    public void SetSpawn(float x, float y)
    {
        spawnX = x;
        spawnY = y;

        Debug.Log("Spawn set");
    }

    //Respawns the player
    public void Respawn()
    {
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.StopTimer();

        lives--;
        if (!lose)
        {
            player.transform.position = new Vector3(spawnX, spawnY, player.transform.position.z);

            died = true;

            StartCoroutine(Delay());
        }
    }

    public void StoreTime(int n)
    {
        store = n;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        died = false;

        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.TimeStart(store);
    }

    // Ends the game
    void GameOver()
    {
        end = true;
        EndBehaviour eb = FindObjectOfType<EndBehaviour>();
        eb.Lose();

        lifeText.text = "";

        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.Goodbye();
    }

    public void Victory()
    {
        win = true;
        Debug.Log("Victory");
        lifeText.text = "";

        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.StopTimer();
        tb.Goodbye();
    }
}
