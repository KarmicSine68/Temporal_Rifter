using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewGameController : MonoBehaviour
{
    public GameObject player;

    public GameObject ready;
    public GameObject not;
    public GameObject usin;

    float spawnX;
    float spawnY;

    int lives;
    public bool end;
    public bool win;
    bool lose;

    public bool died;

    public TMP_Text lifeText;

    int store;

    bool isEnemy;

    bool dev;

    bool enemy;

    // Sets the amount of player lives
    void Start()
    {
        enemy = false;
        
        not.SetActive(false);
        ready.SetActive(false);
        usin.SetActive(false);

        end = false;
        win = false;

        died = false;
        lose = false;

        isEnemy = false;
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

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(dev)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("Time slowed");
                NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
                tb.TimeSlow();
                dev = false;

                usin.SetActive(true);
                ready.SetActive(false);

                StartCoroutine(RanOut());
            }
        }
    }

    IEnumerator RanOut()
    {
            yield return new WaitForSeconds(5);
            Debug.Log("Device Off");
            not.SetActive(true);
            usin.SetActive(false);

            StartCoroutine(Enable());

            NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
            tb.TimeNormal();
    }

    // Reenables the ability to slow time after 10 seconds
    IEnumerator Enable()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("Device On");
        ready.SetActive(true);
        not.SetActive(false);
        dev = true;
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

    // Checks to see if there are enemies in the level
    public void Enemy()
    {
        isEnemy = true;
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
            if (isEnemy == true)
            {
                // Resets the enemy to their starting position
                EnemyBehaviour eb = FindObjectOfType<EnemyBehaviour>();
                eb.EnemyReset();
            }

            player.transform.position = new Vector3(spawnX, spawnY, player.transform.position.z);

            died = true;

            LeverBehaviour lb = FindObjectOfType<LeverBehaviour>();
            //lb.Original();

            // Despawns the chaser if the player dies
            if (enemy)
            {
                ChaserBehaviour cs = FindObjectOfType<ChaserBehaviour>();
                cs.Escaped();
                StartCoroutine(NoEnemy());
            }

            StartCoroutine(Delay());
        }
    }

    public void EnemySpawned()
    {
        enemy = true;
    }

    IEnumerator NoEnemy()
    {
        yield return new WaitForSeconds(1);
        enemy = false;
    }

    // Allows the time slow mechanic to be used
    public void DeviceOn()
    {
        Debug.Log("Device active");

        ready.SetActive(true);

        dev = true;
    }

    // Disables the time slow mechanic for the level
    public void DeviceOff()
    {
        dev = false;
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

        Debug.Log("time resumed");

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
