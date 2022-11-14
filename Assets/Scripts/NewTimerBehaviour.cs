using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTimerBehaviour : MonoBehaviour
{
    public TMP_Text timer1;
    public TMP_Text timer2;

    float time;
    float wait;

    bool start;

    // Doesn't display clock when game is loaded
    void Start()
    {
        start = false;
        timer1.text = "";
        timer2.text = "";
        time = 999;
        wait = 1;
    }

    // The timer
    void Update()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if(!gc.died && !gc.end && start)
        {
            time -= 1 * Time.deltaTime;
        }

        if(time > 10)
        {
            wait = 1;
        }
        else
        {
            wait = 0.5f;
        }
    }

    // Flashes the timer
    public void TimeStart()
    {
        bool swi = false;
        start = true;

        while (time >= 0)
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

            StartCoroutine(Delay());
        }
    }

    // Changes the delay between flashes
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(wait);
    }

    // Stops the timer
    public void StopTimer()
    {
        start = false;
        time = -10;
        timer1.text = "";
        timer2.text = "";
    }
}
