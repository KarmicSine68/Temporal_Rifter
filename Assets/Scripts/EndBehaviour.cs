using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBehaviour : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject next;
    public GameObject replay;
    public GameObject menu;

    public GameObject tele;
    public GameObject cam;

    public GameObject timer1;
    public GameObject timer2;

    // Sets the canvas to unactive at the start
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        next.SetActive(false);
        replay.SetActive(false);
        menu.SetActive(false);

        timer1.SetActive(true);
        timer2.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(tele.transform.position.x, tele.transform.position.y, tele.transform.position.x, tele.transform.position.y);

        cam.transform.position = tele.transform.position;

        winText.SetActive(true);
        next.SetActive(true);
        replay.SetActive(true);
        menu.SetActive(true);

        timer1.SetActive(false);
        timer2.SetActive(false);

        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.Victory();
    }

    public void Lose()
    {
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(tele.transform.position.x, tele.transform.position.y, tele.transform.position.x, tele.transform.position.y);

        cam.transform.position = tele.transform.position;

        loseText.SetActive(true);
        replay.SetActive(true);
        menu.SetActive(true);

        timer1.SetActive(false);
        timer2.SetActive(false);
    }
}
