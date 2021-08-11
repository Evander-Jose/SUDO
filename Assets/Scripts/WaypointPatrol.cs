using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPatrol : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public bool cannotFly = true;
    public float movementSpeed = 5f;
    public CharacterController2D controller;

    private List<Transform> _waypoints = new List<Transform>();
    private int currentIndex;
    private Transform waypointHeadingTowards;


    private void Start()
    {      
        string correspondingWaypointGroupGameObjectName = "w_" + gameObject.name;
        GameObject waypointGroup = GameObject.Find(correspondingWaypointGroupGameObjectName);

        foreach(Transform t in waypointGroup.transform)
        {
            _waypoints.Add(t);
        }

        currentIndex = 0;
        waypointHeadingTowards = _waypoints[currentIndex];
    }

    private void FixedUpdate()
    {
        if(cannotFly)
        {
            //First, determine the x component of the displacement from the destination:
            //(right is positive)
            float absolute_x_displacement = 0f;
            Vector3 displacement = waypointHeadingTowards.position - transform.position;
            float x_displacement = displacement.x;
            absolute_x_displacement = Mathf.Abs(displacement.x);

            //Debug.Log("Displacement : " + absolute_x_displacement);

            //Keep moving until x_displacement is near zero:
            if (absolute_x_displacement >= 0.1f)
            {
                controller.Move(movementSpeed * Time.fixedDeltaTime * (x_displacement / absolute_x_displacement), false, false);
            } else
            {
                //If that displacement is near zero, then that means the gameobject has successfully moved to its destination, now to look for the next destination:
                SetNextWaypoint();
            }
        }
    }

    private void SetNextWaypoint()
    {
        currentIndex++;

        if (currentIndex > _waypoints.Count-1)
            currentIndex = 0;

        waypointHeadingTowards = _waypoints[currentIndex];
    }

    //This is only going to be used by the custom editor button:
    public void AddWaypoint()
    {
        //Look for the gameobject, "EnemyWaypoints".
        //If it already exists, use that, but if not, then make one.
        GameObject enemyWaypoints = GameObject.Find("EnemyWaypoints");
        if (enemyWaypoints == null)
        {
            enemyWaypoints = new GameObject("EnemyWaypoints");
        }

        //Then, find the game object that groups the waypoints for this specific enemy:
        GameObject waypointsGroup = GameObject.Find("w_" + gameObject.name);
        //If nothing comes up, then just make it:
        if (waypointsGroup == null)
        {
            waypointsGroup = new GameObject("w_" + gameObject.name);
            waypointsGroup.transform.parent = enemyWaypoints.transform;
        }

        //Then create a new waypoint:
        GameObject newWaypoint = new GameObject("waypoint_" + waypoints.Count);
        newWaypoint.transform.parent = waypointsGroup.transform;
        newWaypoint.transform.position = transform.position;

        waypoints.Add(newWaypoint.transform);
    }
}
