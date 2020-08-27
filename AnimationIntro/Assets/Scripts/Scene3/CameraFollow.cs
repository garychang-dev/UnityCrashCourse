using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float angularSpeed;
    public Vector3 offset;

    public float slowDistance;
    public float arrivalDistance;

    private void LateUpdate()
    {
        Vector3 direction = target.transform.position + (transform.rotation * offset) - transform.position;
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

        Quaternion desiredLookRotation = Quaternion.LookRotation(target.transform.forward, target.transform.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredLookRotation, angularSpeed * Time.deltaTime);
    }
}
