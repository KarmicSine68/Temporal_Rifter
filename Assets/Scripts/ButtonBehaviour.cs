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
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
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
}
