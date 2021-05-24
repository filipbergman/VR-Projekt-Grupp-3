using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDispencer : MonoBehaviour
{
    public GameObject ball;
    public GameObject dispenser;

    public float resetTime = 1f;

    public bool triggerd = false;

    private AudioSource audio;
    private Vector3 ballSpawnPos;

    public AudioClip beep;
    void Start()
    {
        ballSpawnPos = dispenser.transform.position;
        ballSpawnPos.z += 0.03f;
        Instantiate(ball, ballSpawnPos, dispenser.transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.right*100);
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        if(triggerd){
            resetTime -= Time.deltaTime;
            if(resetTime < 0){
                triggerd = false;
                resetTime = 1f;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(!triggerd){
            audio.PlayOneShot(beep, 0.4f);
            Instantiate(ball, ballSpawnPos, dispenser.transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
            triggerd = true;
        }
        //Instantiate(ball, transform.position, transform.rotation);
        //ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
        
    }
}
