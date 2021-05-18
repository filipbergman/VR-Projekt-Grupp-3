using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        Debug.Log("OPEN");
        animator.SetBool("isOpening", true);   
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpening", false);
    }
}

