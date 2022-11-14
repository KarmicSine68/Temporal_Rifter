using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public void Level1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Instructions()
    {
        InstructionBehaviour ib = FindObjectOfType<InstructionBehaviour>();

        ib.Display();
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Level2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void Level3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void Leave()
    {
        Application.Quit();
    }

    public void Close()
    {
        InstructionBehaviour ib = FindObjectOfType<InstructionBehaviour>();

        ib.UnDisplay();
    }
}
