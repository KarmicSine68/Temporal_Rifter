using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class TimerBehaviour : MonoBehaviour
{
    public TMP_Text timer;
    public TMP_Text timer2;
    bool change;
    int seconds;
    int msec;
    int save;
    int time;

    bool alive;

    // Start is called before the first frame update
    private void Start()
    {
        timer2.text = "";
        timer.text = "";
        seconds = 999;
        time = 1000;
    }
    public void StartTimer(int s)
    {
        msec = 1000;
        change = false;
        seconds = s;
        save = s;
        alive = true;
        Countdown();
        Flash();
    }

    public void SlowTime()
    {
        msec *= 2;
        time *= 2;
    }

    public void ResumeTime()
    {
        msec /= 2;
        time /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds <= 10)
        {
            msec = 500;
        }
        else
        {
            msec = 1000;
        }

        if (!alive)
        {
           alive = true;
        }

    }

    async private void Flash()
    {
        while (seconds > 0 && alive)
        {
            if (change)
            {
                timer2.text = "";
                timer.text = seconds.ToString();
                change = false;
            }
            else
            {
                timer.text = "";
                timer2.text = seconds.ToString();
                change = true;
            }
            await Task.Delay(msec);
        }
    }

    async public void Countdown()
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();

        while (alive)
        {
            await Task.Delay(time);
            seconds -= 1;

            if (seconds <= 0)
            {
                gc.Respawn();
                alive = false;
            }
        }
    }

    public void StopTimer()
    {
        StartTimer(save);
    }

    public void EndTimer()
    {
        seconds = -10;
        timer.text = "";
        timer2.text = "";
    }
}
