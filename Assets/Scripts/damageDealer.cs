using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class damageDealer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            //do stuff here

        }
    }
}