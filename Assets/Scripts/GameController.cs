using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
    public GameObject replay;
    public GameObject menu;
    public GameObject winText;
    public GameObject loseText;
    public GameObject backdrop;

    public GameObject player;

    public GameObject cam;

    public GameObject check;

    public TMP_Text life;
    int lives;

    float teleY;
    float camY;
    float changeX;

    float spawnX;

    bool use;

    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = new Vector3(0, -8.9f, 0);

        replay.SetActive(false);
        menu.SetActive(false);
        backdrop.SetActive(false);
        loseText.SetActive(false);
        winText.SetActive(false);

        lives = 5;

        teleY = -8.9f;
        camY = -26.76f;

        use = false;

        alive = true;
    }

    public void SetSpawn(float x)
    {
        spawnX = x;
    }

    public void Device()
    {
        check.SetActive(true);
        Debug.Log("Device picked up");
        use = true;
    }

    // Update is called once per frame
    async void Update()
    {
        TimedDoorBehaviour tbd = GameObject.FindObjectOfType<TimedDoorBehaviour>();
        TimerBehaviour tb = GameObject.FindObjectOfType<TimerBehaviour>();

        if (alive)
        {
            life.text = ": " + lives.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space) && use)
        {
            check.SetActive(false);
            tbd.SlowTime();
            tb.SlowTime();
            use = false;

            await Task.Delay(10000);
            check.SetActive(true);
            use = true;
            Debug.Log("Device ready");
            tbd.ResumeTime();
            tb.ResumeTime();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void GameOver()
    {
        TimerBehaviour tb = GameObject.FindObjectOfType<TimerBehaviour>();
        tb.EndTimer();

        replay.SetActive(true);
        menu.SetActive(true);
        backdrop.SetActive(true);
        alive = false;
        life.text = "";
        player.transform.position = new Vector3(-9999, player.transform.position.y, player.transform.position.z);
    }

    public void Respawn()
    {
        if (lives != 999)
        {
            lives--;
        }
        if (lives > 0)
        {
            player.transform.position = new Vector3(spawnX, teleY, 0);
            cam.transform.position = new Vector3(spawnX, camY + 30, -10);

            TimerBehaviour tb = GameObject.FindObjectOfType<TimerBehaviour>();
            tb.StartTimer(25);

            use = true;
        }
        else
        {
            loseText.SetActive(true);
            GameOver();
        }
    }

    public void Instructions()
    {
        TimerBehaviour tb = GameObject.FindObjectOfType<TimerBehaviour>();
        tb.StartTimer(999);

        lives = 999;
    }

    public void Teleport()
    {
        teleY -= 27;
        changeX = -17.7f;
        player.transform.position = new Vector3(changeX, teleY, 0);
        cam.transform.position = new Vector3(0, camY, -10);
        camY -= 30;

        TimerBehaviour tb = GameObject.FindObjectOfType<TimerBehaviour>();
        tb.StartTimer(25);
    }

    public void Victory()
    {
        winText.SetActive(true);
        GameOver();
    }
}
