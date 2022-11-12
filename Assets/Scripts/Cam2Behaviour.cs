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

    void Start()
    {
        transform.position = new Vector3(person.transform.position.x, 0, transform.position.z);
        yMin = min.transform.position.y;
        xMin = min.transform.position.x;
        xMax = max.transform.position.x;
        yMax = max.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (person.transform.position.x >= xMin && person.transform.position.x <= xMax)
        {
            transform.position = new Vector3(person.transform.position.x, transform.position.y, transform.position.z);
        }

        if (person.transform.position.y >= yMin && person.transform.position.y <= yMax)
        {
            transform.position = new Vector3(transform.position.x, person.transform.position.y, transform.position.z);
        }
    }

    public void Position(float xMi, float yMi, float xMa, float yMa)
    {
        xMax = xMa;
    }
}
