using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTimerBehaviour : MonoBehaviour
{
    public TMP_Text timer1;
    public TMP_Text timer2;

    int time;
    //float wait;

    bool start;
    bool swi;

    bool slow;

    // Doesn't display clock when game is loaded
    void Start()
    {
        swi = false;
        start = false;
        slow = false;
        timer1.text = "";
        timer2.text = "";
        time = 999;

        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.StoreTime(time);
    }

    // Decreases the time by 1 second every second
    void Countdown()
    {
        if(start == false)
        {
            CancelInvoke("Countdown");
        }
        
        time -= 1;
    }

    // Starts the timer
    public void TimeStart(int n)
    {
        Debug.Log("Countdown successful");

        time = n;

        start = true;
        if (time != 999)
        {
            InvokeRepeating("Flash", 0, 1);
            InvokeRepeating("Countdown", 0, 1);
        }
    }

    public void TimeSlow()
    {
        start = true;

        CancelInvoke("Countdown");
        CancelInvoke("Flash");
        CancelInvoke("Fast");

        slow = true;

        InvokeRepeating("Countdown", 2, 4);
        if (time > 10)
        {
            InvokeRepeating("Flash", 1, 4);
        }
        else if((0 < time) && (time <= 10))
        {
            InvokeRepeating("Fast", 0.5f, 2);
        }

        TimedDoorBehaviour tdb = FindObjectOfType<TimedDoorBehaviour>();
        tdb.SlowTime();

        EnemyBehaviour eb = FindObjectOfType<EnemyBehaviour>();
        eb.TimeSlow();
    }

    public void TimeNormal()
    {
        CancelInvoke("Countdown");
        CancelInvoke("Flash");
        CancelInvoke("Fast");
        if (!swi)
        {
            timer1.text = time.ToString();
            timer2.text = "";
            swi = true;
        }
        else
        {
            timer1.text = "";
            timer2.text = time.ToString();
            swi = false;
        }

        slow = true;

        InvokeRepeating("Countdown", 2, 1);
        if (time > 10)
        {
            InvokeRepeating("Flash", 1, 1);
        }
        else if ((0 < time) && (time <= 10))
        {
            InvokeRepeating("Fast", 1, 0.5f);
        }
        TimedDoorBehaviour tdb = FindObjectOfType<TimedDoorBehaviour>();
        tdb.ResumeTime();

        EnemyBehaviour eb = FindObjectOfType<EnemyBehaviour>();
        eb.TimeNormal();
    }

    // Flashes the timer
    void Flash()
    {
        // stops the timer from counting down
        if(start == false)
        {
            //time = 0;
            CancelInvoke();
            timer1.text = "";
            timer2.text = "";
        }

        if (start)
        {
            // Displays the time
            if (!swi)
            {
                timer1.text = time.ToString();
                timer2.text = "";
                swi = true;
            }
            else
            {
                timer1.text = "";
                timer2.text = time.ToString();
                swi = false;
            }
        }

        // Switches to a faster flash for the last 10 seconds
        if(time <= 10)
        {
            CancelInvoke();
            if (slow)
            {
                InvokeRepeating("Fast", 0, 2f);
                InvokeRepeating("Countdown", 1, 4);
            }
            else
            {
                InvokeRepeating("Fast", 0, 0.5f);
                InvokeRepeating("Countdown", 1, 1);
            }
        }
    }

    // Flashes the timer faster
    void Fast()
    {
        // Stops the timer
        if (start == false)
        {
            CancelInvoke();
            timer1.text = "";
            timer2.text = "";
        }

        // Respawns the player if they run out of time
        if(time <= 0)
        {
            CancelInvoke();

            NewGameController gc = FindObjectOfType<NewGameController>();
            gc.Respawn();
        }

        // Displays the time
        if (start)
        {
            if (!swi)
            {
                timer1.text = time.ToString();
                timer2.text = "";
                swi = true;
            }
            else
            {
                timer1.text = "";
                timer2.text = time.ToString();
                swi = false;
            }
        }
    }

    // Stops the timer
    public void StopTimer()
    {
        start = false;
        timer1.text = "";
        timer2.text = "";
        Debug.Log("Timer stopped");
    }

    // Stops displaying the time for the win and lose screen
    public void Goodbye()
    {
        start = false;
        timer1.text = "";
        timer2.text = "";
    }
}
