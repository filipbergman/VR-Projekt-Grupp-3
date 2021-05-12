using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTrapRelease : MonoBehaviour
{
    public bool triggerd = false;
    private Quaternion trapOpen;
    private Quaternion trapClosed;
    public float fullyOpen = 180f;
    public float speed = 3f;
    private float startTime = 0f;
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if (startTime > 0f)
        //{
        
        //}

    }



    void OnMouseDown()
    {
        triggerd = !triggerd;
        //startTime = Time.time;
        if (triggerd)
            trans.Translate(0f, 2f, 0f);
        else
            trans.Translate(0f, -2f, 0f);
    }
}
