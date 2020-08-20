using UnityEngine;

public class TranslateToTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float arrivalDistance = 0.1f;

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > arrivalDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
