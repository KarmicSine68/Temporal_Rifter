using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject moveText;

    private void Start()
    {
        moveText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        moveText.SetActive(false);
    }
}
