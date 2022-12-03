using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceEnabled : MonoBehaviour
{
    // Enables the time slow device for the level
    void Start()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();

        gc.DeviceOn();
    }
}
