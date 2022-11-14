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

    public bool died;

    public TMP_Text lifeText;

    // Sets the amount of player lives
    void Start()
    {
        lives = 5;
        end = false;
        died = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            end = true;
            GameOver();
        }
        else
        {
            lifeText.text = "Lives: " + lives.ToString();
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
            player.transform.position = new Vector3(spawnX, spawnY, transform.position.z);

            lives--;
        }
        died = true;
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        died = false;
    }

    void GameOver()
    {
        EndBehaviour eb = FindObjectOfType<EndBehaviour>();
        eb.Lose();
        lifeText.text = "";
    }
}
