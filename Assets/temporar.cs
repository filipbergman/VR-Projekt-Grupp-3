using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class temporar : MonoBehaviour
{
    private SteamVR_LoadLevel ll;
    // Start is called before the first frame update
    void Start()
    {
        ll = GetComponent<SteamVR_LoadLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.transform.root.name == "Player") {
            
            ll.Trigger();
            other.gameObject.transform.root.position = Vector3.zero;
        }
    }
}
