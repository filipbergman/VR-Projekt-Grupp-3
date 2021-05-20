using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{

    public GameObject[] traps;
    private AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") {
            hitSound.Play();
            foreach (GameObject trap in traps)
                trap.GetComponent<disarm>().disarmTrap();
                this.GetComponentInParent<Activated>().toggleActive();
        }
    }
}
