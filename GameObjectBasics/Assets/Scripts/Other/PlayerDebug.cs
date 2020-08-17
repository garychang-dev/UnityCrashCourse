using UnityEngine;

public class PlayerDebug : MonoBehaviour
{
    public float sphereGizmoRadius;

    public void SayHello()
    {
        Debug.Log("Hello world!");
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sphereGizmoRadius);
    }
}
