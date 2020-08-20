using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("RemoveKinematicProperty", 0.25f);
        }
    }

    private void RemoveKinematicProperty()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
