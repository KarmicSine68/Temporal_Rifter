using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteText : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(false); 
    }
}
