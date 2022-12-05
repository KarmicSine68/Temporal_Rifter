using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnding : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
