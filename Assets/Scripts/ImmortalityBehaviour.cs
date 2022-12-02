using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmortalityBehaviour : MonoBehaviour
{
    // Sets the player's lives to 999
    void Start()
    {
        NewGameController gc = FindObjectOfType<NewGameController>();
        gc.SetImmortal();
    }
}
