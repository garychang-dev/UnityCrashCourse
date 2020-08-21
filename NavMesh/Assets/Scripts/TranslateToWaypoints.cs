using UnityEngine;

public class TranslateToWaypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed;
    public float rotationSpeed;

    private int waypointIndex = 0;
    private const float ARRIVAL_DISTANCE = 0.1f;

    void Update()
    {
        Vector3 direction = GetWaypointPosition() - transform.position;
        if (direction.magnitude > ARRIVAL_DISTANCE)
        {
            // Continue translating until the distance to waypoint is small enough
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

            // Rotate towards direction
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Move on to the next waypoint
            waypointIndex++;

            // Reset back to first waypoint if there are no other waypoints left
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }

    // Helper function to prevent a null reference
    private Vector3 GetWaypointPosition()
    {
        if (waypointIndex >= waypoints.Length)
        {
            return Vector3.zero;
        }
        return waypoints[waypointIndex].position;
    }
}
