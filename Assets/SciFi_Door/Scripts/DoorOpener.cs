using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator animator;

    public string doorID;
    public string doorCode; // TODO

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor(string code)
    {
        if(code == doorID) 
        {
            animator.SetBool("isOpening", true);   
        }
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpening", false);
    }
}

