using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionBehaviour : MonoBehaviour
{
    public GameObject instructions;
    public GameObject close;
    public GameObject start;
    public GameObject help;
    public GameObject leave;

    private void Start()
    {
        instructions.SetActive(false);
        close.SetActive(false);
        start.SetActive(true);
        help.SetActive(true);
        leave.SetActive(true);
    }

    public void Display()
    {
        instructions.SetActive(true);
        close.SetActive(true);
        start.SetActive(false);
        help.SetActive(false);
        leave.SetActive(false);
    }

    public void UnDisplay()
    {
        instructions.SetActive(false);
        close.SetActive(false);
        start.SetActive(true);
        help.SetActive(true);
        leave.SetActive(true);
    }
}
