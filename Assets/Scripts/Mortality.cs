using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortality : MonoBehaviour
{
    // Sets the players lives
    void Start()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.SetMortal();
    }
}
