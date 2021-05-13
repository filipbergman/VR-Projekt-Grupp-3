using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBond : MonoBehaviour
{
    public GameObject target;
    private GameObject bondCamera;

    private Vector3 currPos;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform.Find("SteamVRObjects").Find("VRCamera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        currPos = transform.position;
        transform.position = new Vector3(target.transform.position.x, currPos.y, target.transform.position.z);
    }
}
