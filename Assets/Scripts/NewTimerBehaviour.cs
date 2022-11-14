using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewTimerBehaviour : MonoBehaviour
{
    public TMP_Text timer1;
    public TMP_Text timer2;

    int time;
    float wait;

    // Start is called before the first frame update
    void Start()
    {
        timer1.text = "";
        timer2.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        if(!gc.end)
        {

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

    public void TimeStart(int n)
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        Debug.Log("Time started");
        Flash();
        while(!gc.died && gc.end)
        {
            time = n;
            StartCoroutine(Countdown());
            n--;
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(wait);
    }

    void Flash()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();
        bool swi = false;

        while (!gc.died && gc.end)
        {
            if(!swi)
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
}
