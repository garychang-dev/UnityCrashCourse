using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovePosition : MonoBehaviour
{
    public float speed;

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
        Vector3 nextPosition = transform.position + (m_Direction * speed * Time.deltaTime);
        m_Rigidbody.MovePosition(nextPosition);
    }
}
