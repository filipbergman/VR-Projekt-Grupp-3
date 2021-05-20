using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{

    public GameObject ball;
    public float coolDown = 3f;
    public GameObject dispenser;
    
    public bool ballReady = true;
    void Update() {
        Debug.Log("Ball Ready: " + ballReady);
    }

    IEnumerable BallCooldown() {
        yield return new WaitForSeconds(coolDown);
        Debug.Log("Cooldown done");
        ballReady = true;
    }

    public void spawnABallPlease() {
        if (ballReady) {
            Debug.Log("jag har tryckt på knappen");
            Instantiate(ball, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(dispenser.transform.forward);
            ballReady = false;
            StartCoroutine("BallCooldown");
        }
    }
}
