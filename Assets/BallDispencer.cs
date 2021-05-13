using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDispencer : MonoBehaviour
{
    public GameObject ball;
    public GameObject dispenser;

    
    void Start()
    {
        GameObject newBall = Instantiate(ball, dispenser.transform.position, dispenser.transform.rotation);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        GameObject newBall = Instantiate(ball, transform.position, transform.rotation);
    }
}
