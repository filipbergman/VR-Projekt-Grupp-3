using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activated : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion targetDown;
    private Quaternion targetUP;

    public float startTime = 10f;
    private float resetTime = 0f;
    private float speed = 1f;

    public bool active = false;

    public float fullyOpen = 90f;
    void Start()
    {
        targetDown = Quaternion.identity;
        targetUP = Quaternion.Euler(0f, 0f,  -fullyOpen);
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            if(startTime < 2)
                startTime += Time.deltaTime / speed;
            transform.localRotation = Quaternion.Lerp(targetUP, targetDown, startTime);
        }else{
            if(startTime < 2)
                startTime += Time.deltaTime / speed;
            transform.localRotation = Quaternion.Lerp(targetDown, targetUP, startTime);
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
