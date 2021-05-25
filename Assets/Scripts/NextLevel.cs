using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class NextLevel : MonoBehaviour
{
    

    private SteamVR_LoadLevel ll;

    void Start()
    {
        ll = GetComponent<SteamVR_LoadLevel>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.transform.root.name == "Player") {
            
            ll.Trigger();
            other.gameObject.transform.root.position = Vector3.zero;
        }
    }

}
