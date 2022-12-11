using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour
{
    private void Awake()
    {
        InvokeRepeating("Chase", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject player = GameObject.Find("Player");
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5);
    }

    void Chase()
    {
        GameObject player = GameObject.Find("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.Respawn();
    }

    public void Escaped()
    {
        Debug.Log("goodbye");
        Destroy(gameObject);
    }
}
