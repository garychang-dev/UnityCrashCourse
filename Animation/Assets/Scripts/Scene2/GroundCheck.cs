using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask layerMask;
    private BoxCollider m_Collider;
    private bool m_IsGrounded;

    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 boxSize = m_Collider.bounds.extents;
        boxSize.y = 0.05f;
        float maxCastDistance = m_Collider.bounds.extents.y + 0.05f;

        m_IsGrounded = Physics.BoxCast(transform.position, boxSize, Vector3.down, transform.rotation, maxCastDistance, layerMask);
    }

    public bool IsGrounded()
    {
        return m_IsGrounded;
    }
}
