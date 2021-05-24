using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator animator;
    public AudioClip doorSound;
    private AudioSource audio;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audio = GetComponentInChildren<AudioSource>();
    }

    public void OpenDoor()
    {
        Debug.Log("OPEN");
        audio.PlayOneShot(doorSound, 1f);
        animator.SetBool("isOpening", true);   
    }

    public void CloseDoor()
    {
        audio.PlayOneShot(doorSound, 1f);
        animator.SetBool("isOpening", false);
    }
}

