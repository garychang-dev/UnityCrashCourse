using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpForce;
    public ForceMode forceMode;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
        }
    }
}
