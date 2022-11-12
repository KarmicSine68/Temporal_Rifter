using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2Behaviour : MonoBehaviour
{
    public GameObject person;

    public GameObject min;
    public GameObject max;

    float xMax;
    float xMin;

    float yMin;
    float yMax;

    //Sets the starting position of the camera to the player's position
    void Start()
    {
        transform.position = new Vector3(person.transform.position.x, 0, transform.position.z);
        yMin = min.transform.position.y;
        xMin = min.transform.position.x;
        xMax = max.transform.position.x;
        yMax = max.transform.position.y;
    }

    //Camera follows the player movement
    void Update()
    {
        //Stops the camera from following the player if the go to far left or right to avoid the camera going out of bounds
        if (person.transform.position.x >= xMin && person.transform.position.x <= xMax)
        {
            transform.position = new Vector3(person.transform.position.x, transform.position.y, transform.position.z);
        }

        if(person.transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }

        if (person.transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }

        //Stops the camera from following the player if the go to far up or down to avoid the camera going out of bounds
        if (person.transform.position.y >= yMin && person.transform.position.y <= yMax)
        {
            transform.position = new Vector3(transform.position.x, person.transform.position.y, transform.position.z);
        }

        if (person.transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }

        if (person.transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }

    }

    //Sets the new boundaries for the camera
    public void Position(float xMi, float yMi, float xMa, float yMa)
    {
        xMin = xMi;
        yMin = yMi;
        xMax = xMa;
        yMax = yMa;
    }
}
