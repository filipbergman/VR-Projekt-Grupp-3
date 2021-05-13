using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallDispencer : MonoBehaviour
{
    public GameObject ball;
    public GameObject dispenser;

    void Start()
    {
        //Instantiate(ball, dispenser.transform.position, dispenser.transform.rotation);
        //ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.right*100);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        //Instantiate(ball, transform.position, transform.rotation);
        //ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
        
    }
}
