using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEndBehaviour : MonoBehaviour
{
    public GameObject winText;
    public GameObject loseText;
    public GameObject replay;
    public GameObject menu;

    public GameObject tele;
    public GameObject cam;

    // Sets the canvas to unactive at the start
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        replay.SetActive(false);
        menu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cam2Behaviour cb = FindObjectOfType<Cam2Behaviour>();
        cb.Position(tele.transform.position.x, tele.transform.position.y, tele.transform.position.x, tele.transform.position.y);

        cam.transform.position = tele.transform.position;

        winText.SetActive(true);
        replay.SetActive(true);
        menu.SetActive(true);

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
    }
}
