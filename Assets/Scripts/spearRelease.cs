using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearRelease : MonoBehaviour
{
    public Transform trans;
    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 deactivatedPos;
    public Vector3 to;
    public Vector3 from;
    public bool moving;
    public float retractionTime;
    public float resetTime = 1;
    public float t;
    public bool armed;
    public AudioClip releaseSound;
    public AudioClip resetSound;
    public AudioClip disarmSound;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        pointA = trans.localPosition;
        pointB = trans.localPosition;
        deactivatedPos = trans.localPosition;
        pointB.y += 2.4f;
        deactivatedPos.y -= 0.5f;
        moving = false;
        retractionTime = 2f;
        to = pointB;
        from = pointA;
        t = 0f;
        armed = true;
        audio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (t < 1f)
            {
                t += Time.deltaTime / retractionTime;

                trans.localPosition = Vector3.Lerp(from, to, t);
            }
            else {
                audio.PlayOneShot(resetSound, 0.4f);
                moving = false;
                t = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (armed) {
            audio.PlayOneShot(releaseSound, 0.4f);
            moving = true;
            to = pointA;
            from = pointB;
        }
    }

    public void armTrap()
    {
        armed = true;
        trans.localPosition = pointA;
    }
    public void disarmTrap()
    {
        audio.PlayOneShot(resetSound, 0.4f);
        armed = false;
        trans.localPosition = deactivatedPos;
        moving = false;
        t = 0;
    }
}
    
