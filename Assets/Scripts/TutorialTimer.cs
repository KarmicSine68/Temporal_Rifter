using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTimer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewTimerBehaviour tb = FindObjectOfType<NewTimerBehaviour>();
        tb.TimeStart(999);

        Destroy(gameObject);
    }
}
