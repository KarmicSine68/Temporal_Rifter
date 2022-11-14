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

    public bool died;

    public TMP_Text lifeText;

    int time;

    // Sets the amount of player lives
    void Start()
    {
        lives = 5;
        end = false;
        win = false;

        died = false;
        time = 0;
    }

    // Ends the game when the player runs out of lives
    void Update()
    {
        if (lives < 0)
        {
            end = true;
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
        if (!end)
        {
            NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
            player.transform.position = new Vector3(spawnX, spawnY, player.transform.position.z);

            lives--;

            tb.TimeStart();
        }
        died = true;
        
        StartCoroutine(Delay());

    }

    public void SetTime(int n)
    {
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();

        time = n;

        tb.TimeStart();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        died = false;
    }

    // Ends the game
    void GameOver()
    {
        EndBehaviour eb = FindObjectOfType<EndBehaviour>();
        eb.Lose();
        lifeText.text = "";
    }

    public void Victory()
    {
        win = true;
        Debug.Log("Victory");
        lifeText.text = "";
    }
}
