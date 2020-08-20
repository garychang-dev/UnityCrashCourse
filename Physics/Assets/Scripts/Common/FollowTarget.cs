using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float speed;

    public float slowDistance;
    public float arrivalDistance;


    private void LateUpdate()
    {
        Vector3 direction = (target.transform.position + offset) - transform.position;
        float distance = direction.magnitude;

        if (distance > slowDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else if (distance > arrivalDistance)
        {
            float percentage = (distance - arrivalDistance) / (slowDistance - arrivalDistance);
            transform.Translate(direction.normalized * speed * percentage * Time.deltaTime, Space.World);
        }
    }
}
