using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
   // public GameObject ball;
    public float speed = 5f;
    public float turnspeed = 35f;
    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime, 0f);
        moveDirection = transform.forward * Input.GetAxis("Vertical");
        characterController.Move(moveDirection * Time.deltaTime * speed);
       
      /*  if (Input.GetKeyDown("b"))
        {
            var clone = Instantiate(ball, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 10f);
        } */
    }
}
