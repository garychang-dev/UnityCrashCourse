using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 eulerRotation;

    void Update()
    {
        transform.Rotate(eulerRotation * Time.deltaTime);
    }
}
