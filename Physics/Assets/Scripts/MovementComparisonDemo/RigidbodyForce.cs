using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyForce : MonoBehaviour
{
    public float forceMultiplier;
    public ForceMode forceMode;

    private Rigidbody m_Rigidbody;
    private Vector3 m_Direction;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_Direction = BasicInput.GetInputDirection(true);
    }

    void FixedUpdate()
    {
        m_Rigidbody.AddForce(m_Direction * forceMultiplier, forceMode);
    }
}
