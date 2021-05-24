using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    private Animator animator;
    public AudioClip doorSound;
    private AudioSource audioSpeaker;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSpeaker = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        Debug.Log("OPEN");
        audioSpeaker.PlayOneShot(doorSound, 1f);
        animator.SetBool("isOpening", true);   
    }

    public void CloseDoor()
    {
        audioSpeaker.PlayOneShot(doorSound, 1f);
        animator.SetBool("isOpening", false);
    }
}

