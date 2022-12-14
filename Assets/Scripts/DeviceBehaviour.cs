using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewGameController gc = GameObject.FindObjectOfType<NewGameController>();
        gc.DeviceOn();
        Destroy(gameObject);
    }
}
