using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoorBehaviour : MonoBehaviour
{
    public GameObject door;
    bool near = false;
    bool push;

    float time;

    private void Start()
    {
        push = false;
        time = 0.5f;
    }

    void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Push();
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        near = true;
    }

    private void Push()
    {
        Vector3 doorPos = door.transform.position;
        if (!push)
        {
            push = true;
            doorPos.y += 5f;
            door.transform.position = doorPos;
            Debug.Log("Button pushed");
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(time);
        Vector3 doorPos = door.transform.position;
        doorPos.y -= 5f;
        door.transform.position = doorPos;
        Debug.Log("Door closed");
        push = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        near = false;
    }

    public void SlowTime()
    {
        time *= 4;
    }

    public void ResumeTime()
    {
        time /= 4;
    }
}
