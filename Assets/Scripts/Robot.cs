using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Robot : MonoBehaviour
{
    public enum STATE
    {
        patrolling,
        chasing,
        searching
    }

    [Header("Settings")]
    [Tooltip("The actual GameObject that the robot will target. Must have a collider.")]
    public GameObject target;
    public GameObject[] controlPoints;
    public float fieldOfView = 45;
    public float searchTimer = 5f;
    public float sightDist = 100f;
    public float patrollSpeed = 2f;
    public float chaseSpeed = 4f;
    public float searchRotationSpeed = 30f;

    public float controlPointDistBias = 0.1f;

    [Header("Debug")]
    public STATE robotState = STATE.patrolling;
    public bool showRay = false;
    public bool showControlPoints = false;

    private NavMeshAgent agent;
    private GameObject indicatorSphere;
    private int currentControlPointIndex = 0;
    private GameObject currentControlPoint;
    private bool forwardDirection;
    private Vector3 targetLastSeenAt;

    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();

        if (controlPoints.Length < 1)
            Debug.LogError("Please add at least one Control Point!");
        else
        {
            currentControlPoint = controlPoints[currentControlPointIndex];
            agent.SetDestination(currentControlPoint.transform.position);

            if (!showControlPoints)
            {
                foreach (GameObject cp in controlPoints)
                    cp.transform.localScale = Vector3.zero;
            }
        }

        indicatorSphere = transform.Find("IndicatorSphere").gameObject;
    }

    void Update()
    {
        switch (robotState) 
        {
            case STATE.chasing:
                Chase();
                break;
            case STATE.searching:
                Search();
                break;
            case STATE.patrolling:
                Patroll();
                break;
        }

        HandleDetection();
    }

    private void Chase()
    {
        StopCoroutine(SearchTimerRoutine());
        agent.isStopped = false;

        agent.SetDestination(targetLastSeenAt);
        agent.speed = chaseSpeed;

        if (Vector3.Distance(transform.position, targetLastSeenAt) < 2f )
        {
            robotState = STATE.searching;
            StartCoroutine(SearchTimerRoutine());
        }       
    }

    private void Search()
    {
        agent.isStopped = true;

        transform.Rotate(Vector3.up, searchRotationSpeed * Time.deltaTime);

    }

    private void Patroll()
    {
        StopCoroutine(SearchTimerRoutine());
        agent.isStopped = false;
        agent.speed = patrollSpeed;

        if (!(Vector3.Distance(transform.position, currentControlPoint.transform.position) < controlPointDistBias))
            agent.SetDestination(currentControlPoint.transform.position);
        else
            NextControlPoint();
    }

    IEnumerator SearchTimerRoutine()
    {
        yield return new WaitForSeconds(searchTimer);
        robotState = STATE.patrolling;
    }

    private void HandleDetection()
    {
        RaycastHit hit;

        Vector3 rayOrigin = transform.position + Vector3.up * 2;

        Vector3 toTarget = (target.transform.position - rayOrigin) + (Vector3.up * 0.5f);
        float angleToTarget = Vector3.Angle(transform.forward, toTarget);

        //DEBUG
        if (showRay)
            Debug.DrawRay(rayOrigin, toTarget, Color.red);
        
        if (angleToTarget < fieldOfView)
        {
            if (Physics.Raycast(rayOrigin, toTarget, out hit, sightDist))
            {
                if (hit.collider.gameObject.transform.root.name == "Player")
                {
                    targetLastSeenAt = hit.collider.gameObject.transform.position;

                    TargetSpotted();

                    //DEBUG
                    indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
                }

                //DEBUG
                else
                    indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
            }
        }

        //DEBUG-------
        else
            indicatorSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
    }

    private void TargetSpotted()
    {
        Debug.Log("Player spotted!");
        robotState = STATE.chasing;
    }

    private void NextControlPoint()
    {
        //Go to next control point unless the robot is at either end of the path
        //If it is, switch direction
        if (forwardDirection)
        {
            if (currentControlPointIndex >= controlPoints.Length - 1)
            {
                forwardDirection = false;
                currentControlPointIndex--;
            }
            else
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

        //Set destination
        agent.SetDestination(currentControlPoint.transform.position);
    }
}
