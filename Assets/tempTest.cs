using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balltarget;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        balltarget.GetComponent<Activated>().toggleActive();
        
    }
}
