using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSystem : MonoBehaviour
{
    /*
    [Header("General")]
    public float moveSpeed = 1f;
    public float acceleration = 1f;
    public float turnSpeed = 1f;
    public float fieldOfView = 45;
    public float sightDist = 100f;

    [Header("Settings")]
    [Tooltip("The actual GameObject that the robot will target. Must have a collider.")]
    public GameObject targetPlayer;
    public GameObject[] controlPoints;

    [Header("Tweaks")]
    public float decelerationDistance = 1f;
    public float controlPointDistBias = 0.1f;
    public float controlPointRotBias = 1f;
    public float stoppedSpeedBias = 0.2f;

    [Header("Debug")]
    public float currentSpeed;
    public bool showRay = false;
    public bool showControlPoints = false;
    
    private GameObject indicatorSphere;
    
    private Robot robot;
    private int currentControlPointIndex = 0;
    private GameObject currentControlPoint;
    private bool forwardDirection;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        robot = gameObject.transform.Find("Robot").GetComponent<Robot>();

        if (controlPoints.Length < 1)
            Debug.LogError("Please add at least one Control Point!");
        else
        {
            currentControlPoint = controlPoints[currentControlPointIndex];

            if (!showControlPoints)
            {
                foreach (GameObject cp in controlPoints)
                    cp.transform.localScale = Vector3.zero;
            }
        }

        indicatorSphere = gameObject.transform.Find("Robot").Find("IndicatorSphere").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        HandleDetection();
    }

    private void HandleMovement()
    {


        //Don't move the robot if it is rotating
        /*if (!isRotating)
        {
            float speed = moveSpeed;

            if (Vector3.Distance(robot.position, currentControlPoint.transform.position) < decelerationDistance)
            {
                speed = 0;

                if (currentSpeed < stoppedSpeedBias)
                    UpdateControlPoint();
            }

            Vector3 direction = (currentControlPoint.transform.position - robot.position).normalized;

            currentSpeed = Mathf.Lerp(currentSpeed, speed, acceleration * Time.deltaTime);

            robot.position += direction * currentSpeed * Time.deltaTime;
        }
        //Rotate
        else
        {
            Quaternion currentRobotRotation = robot.rotation;
            Quaternion targetRobotRotation = currentRobotRotation * Quaternion.FromToRotation(robot.forward, currentControlPoint.transform.position - robot.position);

            robot.rotation = Quaternion.RotateTowards(currentRobotRotation, targetRobotRotation, turnSpeed * Time.deltaTime);

            //Stop rotating when the robot is facing the current control point
            if (Math.Abs(currentRobotRotation.eulerAngles.y - targetRobotRotation.eulerAngles.y) < controlPointRotBias)
                isRotating = false;
        }
        
    }

    private void HandleDetection()
    {
        RaycastHit hit;

        Vector3 toPlayer = (targetPlayer.transform.position - robot.position) + (Vector3.up * 0.5f);
        float angleToPlayer = Vector3.Angle(robot.forward, toPlayer);

        if (angleToPlayer < fieldOfView)
        {
            if (Physics.Raycast(robot.position, toPlayer, out hit, sightDist))
            {
                //DEBUG-------
                if (showRay)
                    Debug.DrawRay(robot.position, toPlayer, Color.red);
                //------------

                if (hit.collider.gameObject.transform.root.name == "Player")
                {
                    indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);

                    PlayerSpotted();
                }

                //DEBUG-------
                else
                {
                    indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
                }
                //------------
            }
        }

        //DEBUG-------
        else
        {
            indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
        }
        //------------
    }

    private void PlayerSpotted()
    {
        Debug.Log("Player spotted!");
    }

    private void UpdateControlPoint()
    {
        //Go to next control point unless the robot is at either end of the path
        //If it is, switch direction
        if (forwardDirection)
        {
            if (currentControlPointIndex >= controlPoints.Length - 1)
            {
                forwardDirection = false;
                currentControlPointIndex--;
            } else 
                currentControlPointIndex++;
        } 
        else
        {
            if (currentControlPointIndex <= 0)
            {
                forwardDirection = true;
                currentControlPointIndex++;
            }
            else
                currentControlPointIndex--;
        }

        //Actually update control point
        currentControlPoint = controlPoints[currentControlPointIndex];

        //Start rotating towards the new control point
        isRotating = true;
    }
    */
}
