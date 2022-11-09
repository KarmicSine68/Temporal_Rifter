using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController gc = GameObject.FindObjectOfType<GameController>();
        gc.Instructions();
    }
}
