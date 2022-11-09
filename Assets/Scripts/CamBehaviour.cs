using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBehaviour : MonoBehaviour
{
    public GameObject person;

    void Start()
    {
        transform.position = new Vector3(person.transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(person.transform.position.x >= 0 && person.transform.position.x <= 114)
        {
            transform.position = new Vector3(person.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
