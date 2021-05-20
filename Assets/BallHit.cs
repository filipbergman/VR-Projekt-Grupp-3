using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{

    public GameObject[] traps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") {
            foreach (GameObject trap in traps)
                trap.GetComponent<disarm>().disarmTrap();
                this.GetComponentInParent<Activated>().toggleActive();
        }
    }
}
