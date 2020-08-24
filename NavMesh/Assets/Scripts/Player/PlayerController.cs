using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private PlayerControls m_PlayerControls;
    private Vector3 m_Direction;
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_PlayerControls = GetComponent<PlayerControls>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Vector2 inputDirection = m_PlayerControls.GetMoveDirection();
        Vector3 direction =  new Vector3(inputDirection.x, 0f, inputDirection.y);
        m_Direction = Vector3.ClampMagnitude(direction, 1f);
    }

    public void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Direction * speed * Time.fixedDeltaTime);
    }
}
