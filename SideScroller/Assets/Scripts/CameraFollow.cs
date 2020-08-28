using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed;

    public float slowDistance;
    public float arrivalDistance;

    void LateUpdate()
    {
        Vector2 direction = new Vector2(target.position.x - transform.position.x, 0f);
        float distance = direction.magnitude;
        if (distance > slowDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
        else if (distance > arrivalDistance)
        {
            float percentage = (distance - arrivalDistance) / (slowDistance - arrivalDistance);
            transform.Translate(direction.normalized * speed * percentage * Time.deltaTime);
        }
    }
}
