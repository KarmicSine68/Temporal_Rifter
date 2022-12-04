using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTime : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.TimeStart(999);
    }
}
