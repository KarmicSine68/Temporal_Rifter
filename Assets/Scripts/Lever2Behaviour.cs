using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2Behaviour : MonoBehaviour
{
    public GameObject door;
    bool near = false;
    bool flip;
    float yrotate;

    private void Start()
    {
        flip = true;
    }

    void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Flip();
                Vector3 rotate = new Vector3(0, yrotate, 0);
                transform.eulerAngles = rotate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        near = true;
    }

    private void Flip()
    {
        Vector3 doorPos = door.transform.position;
        if (flip)
        {
            yrotate = 180;
            doorPos.y -= 5f;
            door.transform.position = doorPos;

            Debug.Log("Lever 1 switched");
            flip = false;
        }
        else
        {
            yrotate = 0;
            doorPos.y += 5f;
            door.transform.position = doorPos;

            Debug.Log("Lever 2 switched");
            flip = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        near = false;
    }
}
