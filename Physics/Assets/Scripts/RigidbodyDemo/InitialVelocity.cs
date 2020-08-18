using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InitialVelocity : MonoBehaviour
{
    public Vector3 velocity;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }
}
