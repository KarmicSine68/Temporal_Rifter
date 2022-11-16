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

    // Doesn't display clock when game is loaded
    void Start()
    {
        swi = false;
        start = false;
        timer1.text = "";
        timer2.text = "";
        time = 999;
    }

    void Countdown()
    {
        if(start == false)
        {
            CancelInvoke("Countdown");
        }
        
        time -= 1;
    }

    // Flashes the timer
    public void TimeStart(int n)
    {
        Debug.Log("Countdown successful");

        time = n;

        start = true;

        InvokeRepeating("Flash", 0, 1);
        InvokeRepeating("Countdown", 0, 1);
    }

    void Flash()
    {
        if(start == false)
        {
            //time = 0;
            CancelInvoke();
        }

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

        if(time <= 10)
        {
            CancelInvoke();
            InvokeRepeating("Fast", 0, 0.5f);
            InvokeRepeating("Countdown", 1, 1);
        }
    }

    void Fast()
    {
        if (start == false)
        {
            //time = 0;
            CancelInvoke();
        }

        if(time <= 0)
        {
            CancelInvoke();

            NewGameController gc = FindObjectOfType<NewGameController>();
            gc.Respawn();
        }

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
        //time = 0;
        timer1.text = "";
        timer2.text = "";
        Debug.Log("Timer stopped");
    }

    public void Goodbye()
    {
        start = false;
        timer1.text = "";
        timer2.text = "";
    }
}
