using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float angularSpeed;
    public Vector3 rotationAxis;

    void Update()
    {
        // Rotate the object around the specified axis and angular speed
        transform.Rotate(rotationAxis, angularSpeed * Time.deltaTime);
    }
}
