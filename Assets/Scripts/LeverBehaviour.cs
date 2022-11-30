using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBehaviour : MonoBehaviour
{
    public GameObject door;
    public GameObject lever;
    bool near = false;
    bool flip;
    float yrotate;

    private void Start()
    {
        flip = false;
    }

    void Update()
    {
        if (near)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Flip();
                Vector3 rotate = new Vector3(0, yrotate, 0);
                lever.transform.eulerAngles = rotate;
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        near = true;
    }

    private void Flip()
    {
        Vector3 doorPos = door.transform.position;
        if (!flip)
        {
            yrotate = 180;
            doorPos.y += 5f;
            door.transform.position = doorPos;

            Debug.Log("Lever 1 switched");
            flip = true;
        }
        else
        {
            yrotate = 0;
            doorPos.y -= 5f;
            door.transform.position = doorPos;

            Debug.Log("Lever 2 switched");
            flip = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        near = false;
    }

    public void Original()
    {
        Vector3 doorPos = door.transform.position;

        if (yrotate == 180)
        {
            yrotate = 0;
            doorPos.y -= 5f;
            door.transform.position = doorPos;

            Debug.Log("Lever 2 switched");
            flip = false;
        }
    }
}
