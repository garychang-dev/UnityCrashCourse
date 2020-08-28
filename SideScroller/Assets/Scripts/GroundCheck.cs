using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask layerMask;
    private CapsuleCollider2D m_Collider;
    private bool m_IsGrounded;

    void Start()
    {
        m_Collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 boxSize = m_Collider.bounds.extents;
        boxSize.y = 0.05f;
        float maxCastDistance = 0.05f;

        
        m_IsGrounded = Physics2D.BoxCast(m_Collider.bounds.center, m_Collider.bounds.size, 0f, Vector2.down, maxCastDistance, layerMask);
    }

    public bool IsGrounded()
    {
        return m_IsGrounded;
    }
}
