using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRelease : MonoBehaviour


{
    public bool triggerd = false;
    private Quaternion trapOpen;
    private Quaternion trapClosed;
    public float fullyOpen = 180f;
    public float speed = 10f;
    private float startTime = 0f;
    public float resetTime = 3f;
    public bool armed = true;

    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        trapOpen = Quaternion.Euler(fullyOpen, 0f, 0f);
        trapClosed = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

        if(moving && triggerd){
            if(startTime < 1f){
                startTime += Time.deltaTime / speed;
                transform.localRotation = Quaternion.Lerp(trapClosed, trapOpen, startTime);
            }
            else{
                moving = false;
                startTime = 0;
            }
        }
        if(triggerd && !moving){
            resetTime -= Time.deltaTime / speed;
            if(resetTime < 0){
                resetTime = 3f;
                triggerd = false;
                moving = true;
            }
        }
        if(moving && !triggerd){
            if(startTime < 1f){
                startTime += Time.deltaTime / speed;
                transform.localRotation = Quaternion.Lerp(trapOpen, trapClosed, startTime);
            }
            else{
                moving = false;
                startTime = 0f;
            }
        }

        
    }



    void OnTriggerEnter()
    {
        if (armed && !moving)
        {
            triggerd = !triggerd;
            moving = true;
        }
        
    }
    public void armTrap()
    {
        armed = true;
    }
    public void dissarmTrap()
    {
        armed = false;
    }
}
