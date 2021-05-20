using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillarGame : MonoBehaviour
{
    public List<GameObject> pillars;
    public float speed = 0.001f;
    public Activated ballTarget;
    public RawImage lockImage;


    private GameObject currPillar;
    private GameObject currMover;

    private int moveUp = -1;
    private int moveIndex = 0;
    private bool won = false;
    private bool gamePlaying = true;

    void Start()
    {
        currPillar = pillars[moveIndex];
        currMover = pillars[moveIndex].transform.GetChild(0).gameObject;

        if(ballTarget == null) {
            lockImage.enabled = true;
            gamePlaying = false;
        }
    }

    void Update() {
        if(gamePlaying) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (currMover.transform.localPosition.z > 0.213f && currMover.transform.localPosition.z < 0.298f) {
                    if (moveIndex < 3) {
                        currPillar = pillars[++moveIndex];
                        currMover = pillars[moveIndex].transform.GetChild(0).gameObject;
                    } else {
                        won = true;
                        Debug.Log("YOU WON!");
                        // TODO call balltarget
                        ballTarget.toggleActive();
                    }
                } else {
                    foreach (GameObject mover in pillars) {
                        Vector3 moverPos = mover.transform.GetChild(0).gameObject.transform.localPosition;
                        mover.transform.GetChild(0).gameObject.transform.localPosition = new Vector3(moverPos.x, moverPos.y, 0);
                    }
                    moveIndex = 0;
                    currPillar = pillars[moveIndex];
                    currMover = pillars[moveIndex].transform.GetChild(0).gameObject;
                }
            }

            if (Mathf.Abs(currMover.transform.localPosition.z) >= 0.483f) {
                moveUp *= -1;
            }
            if (!won) {
                Vector3 currPos = currMover.transform.localPosition;
                currMover.transform.localPosition = new Vector3(currPos.x, currPos.y, currPos.z + moveUp * Time.deltaTime);
            }
        }
    }
}
