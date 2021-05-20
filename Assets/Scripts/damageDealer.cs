using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if(other.gameObject.transform.root.name == "Player") {
            other.gameObject.transform.root.transform.position = Vector3.zero;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}