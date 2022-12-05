using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBehaviour : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}
