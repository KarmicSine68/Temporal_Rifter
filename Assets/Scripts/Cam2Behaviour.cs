using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2Behaviour : MonoBehaviour
{
    public GameObject person;

    float xMax;
    //float yPos;

    void Start()
    {
        transform.position = new Vector3(person.transform.position.x, 0, transform.position.z);
        //yPos = 0;
        xMax = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (person.transform.position.x >= 0 && person.transform.position.x <= xMax)
        {
            transform.position = new Vector3(person.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    public void Position(float n)
    {
        xMax = n;
    }
}
