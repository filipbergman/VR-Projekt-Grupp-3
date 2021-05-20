using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateLock : MonoBehaviour
{
    public bool doors = true;
    public RawImage lockImage;
    // Start is called before the first frame update
    void Start()
    {
        if (!doors)
            lockImage.enabled = true;
        else
            lockImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}