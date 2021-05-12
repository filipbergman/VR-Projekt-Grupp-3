using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearRelease : MonoBehaviour
{
    public bool triggerd = false;
    public Transform trans;
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 to;
    public Vector3 from;
    public bool moving;
    public float time;
    public float resetTime = 1;
    public float t;
    public bool armed;
    // Start is called before the first frame update
    void Start()
    {
        pointA = trans.localPosition;
        pointB = trans.localPosition;
        pointB.y += 2f;
        moving = false;
        time = 1;
        to = pointB;
        from = pointA;
        t = 0f;
        armed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {

            if(t < 1f)
            {
                t += Time.deltaTime / time;

                trans.localPosition = Vector3.Lerp(to, from, t);

                
            }

            moving = false;
        }
        if (triggerd)
        {
            resetTime -= Time.deltaTime;
            if(resetTime < 0)
            {
                resetTime = 1;
                triggerd = false;
                moving = true;
                to = pointA;
                from = pointB;
            }
        }
    }

    void OnTriggerEnter()
    {
        if (armed)
        {
            triggerd = !triggerd;
        }
        
        
        if (triggerd)
        {
            
            moving = true;
            to = pointB;
            from = pointA;
        }
        else
        {
            moving = true;
            to = pointA;
            from = pointB;
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
    
