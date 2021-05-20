using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDispencer : MonoBehaviour
{
    public GameObject ball;
    public GameObject dispenser;

    public float resetTime = 3f;

    public bool triggerd = false;

    private AudioSource audio;

    public AudioClip beep;
    void Start()
    {
        Instantiate(ball, dispenser.transform.position, dispenser.transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.right*100);
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if(triggerd){
            resetTime -= Time.deltaTime;
            if(resetTime < 0){
                triggerd = false;
                resetTime = 3f;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(!triggerd){
            audio.PlayOneShot(beep, 0.4f);
            Instantiate(ball, dispenser.transform.position, dispenser.transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
            triggerd = true;
        }
        //Instantiate(ball, transform.position, transform.rotation);
        //ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
        
    }
}
