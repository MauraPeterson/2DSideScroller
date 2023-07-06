using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        Vector2 waypointPosition = waypoints[currentWaypointIndex].transform.position;
        float distanceFromWaypoint = Vector2.Distance(waypointPosition, transform.position);
        if (distanceFromWaypoint < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypointPosition, Time.deltaTime * speed);
    }
}
