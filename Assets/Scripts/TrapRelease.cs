using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRelease : MonoBehaviour


{
    public bool triggerd = false;
    private Quaternion trapOpen;
    private Quaternion trapClosed;
    public float fullyOpen = 180f;
    public float speed = 3f;
    private float startTime = 0f;
    public float resetTime = 3f;
    public bool armed = true;
    // Start is called before the first frame update
    void Start()
    {
        trapOpen = Quaternion.Euler(fullyOpen, 0f, 0f);
        trapClosed = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (armed)
        {
            if (startTime > 0f)
            {
                if (triggerd)
                    transform.localRotation = Quaternion.Lerp(trapClosed, trapOpen, (Time.time - startTime) * speed);
                else
                    transform.localRotation = Quaternion.Lerp(trapOpen, trapClosed, (Time.time - startTime) * speed);
            }
            if (triggerd)
            {
                resetTime -= Time.deltaTime;
                if (resetTime < 0)
                {
                    triggerd = false;
                    startTime = Time.time;
                }
            }
        }
        

    }



    void OnTriggerEnter()
    {
        if (armed)
        {
            triggerd = !triggerd;
            startTime = Time.time;
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
