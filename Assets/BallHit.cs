using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{

    public GameObject[] traps;
    private AudioSource audio;
    public AudioClip hitsound;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") {
            audio.PlayOneShot(hitsound, 0.4f);
            foreach (GameObject trap in traps)
                trap.GetComponent<disarm>().disarmTrap();
                this.GetComponentInParent<Activated>().toggleActive();
        }
    }
}
