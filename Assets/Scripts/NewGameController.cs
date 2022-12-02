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

        if(Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    // Makes the player able to lose
    public void SetMortal()
    {
        lives = 5;
    }

    //Sets the spawnpoint location
    public void SetSpawn(float x, float y)
    {
        spawnX = x;
        spawnY = y;

        Debug.Log("Spawn set");
    }

    // Makes the player immortal
    public void SetImmortal()
    {
        lives = 999;
    }

    //Respawns the player
    public void Respawn()
    {
        // Stops the timer from counting down
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.StopTimer();

        // Prevents the player from losing lives while immortal
        if (lives != 999)
        {
            lives--;
        }
        if (!lose)
        {
            // Resets the enemy to their starting position
            EnemyBehaviour eb = FindObjectOfType<EnemyBehaviour>();
            eb.EnemyReset();

            player.transform.position = new Vector3(spawnX, spawnY, player.transform.position.z);

            died = true;

            LeverBehaviour lb = FindObjectOfType<LeverBehaviour>();
            lb.Original();

            StartCoroutine(Delay());
        }
    }

    // Stores the timer value of the room
    public void StoreTime(int n)
    {
        store = n;
    }

    // Restarts the timer after the player respawns
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
        // Displays the end screen
        eb.Lose();

        lifeText.text = "";

        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        // Stops displaying the timer
        tb.Goodbye();
    }

    public void Victory()
    {
        // Stops displaying the lives
        win = true;
        Debug.Log("Victory");
        lifeText.text = "";

        // Stops the timer and its display
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.StopTimer();
        tb.Goodbye();
    }
}
