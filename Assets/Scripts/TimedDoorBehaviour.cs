using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TimedDoorBehaviour : MonoBehaviour
{
    public GameObject door;
    bool near = false;
    bool push;

    int time;

    private void Start()
    {
        push = false;
        time = 3000;
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

    async private void Push()
    {
        Vector3 doorPos = door.transform.position;
        if (!push)
        {
            push = true;
            doorPos.y += 3f;
            door.transform.position = doorPos;
            Debug.Log("Button pushed");

            await Task.Delay(time);
            doorPos.y -= 3f;
            door.transform.position = doorPos;
            Debug.Log("Door closed");
            push = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        near = false;
    }

    public void SlowTime()
    {
        time *= 2;
    }

    public void ResumeTime()
    {
        time *= 2;
    }
}
