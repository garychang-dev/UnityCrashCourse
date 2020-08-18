using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementWithVelocity : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.ClampMagnitude(BasicInput.GetInputDirection(), 1f);
        rb.velocity = direction * speed;
    }
}
