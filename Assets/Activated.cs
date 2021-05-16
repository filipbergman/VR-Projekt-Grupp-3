using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activated : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion trapOpen;
    private Quaternion trapClosed;

    private float startTime = 0f;
    private float resetTime = 0f;
    private float speed = 1f;

    public bool active = false;

    public float fullyOpen = 90f;
    void Start()
    {
        trapOpen = Quaternion.Euler(0f, 0f, - fullyOpen);
        trapClosed = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            startTime += Time.deltaTime / speed;
            transform.localRotation = Quaternion.Lerp(trapClosed, trapOpen, startTime);
        }else{
            startTime += Time.deltaTime / speed;
            transform.localRotation = Quaternion.Lerp(trapOpen, trapClosed, startTime);
        }
        if(resetTime > 0){
            resetTime -= Time.deltaTime;
        }
    }
    public void toggleActive(){
        if(resetTime <= 0f){
            active = !active;
            startTime = 0f;
            resetTime = 1f;
        }
        //active = !active;
        //    startTime = 0f;
        
    }

}
