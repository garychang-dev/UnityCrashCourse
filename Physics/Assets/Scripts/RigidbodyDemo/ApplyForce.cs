using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    public Vector3 forceDirection;
    public ForceMode forceMode;

    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            m_Rigidbody.AddForce(forceDirection, forceMode);
        }
    }
}