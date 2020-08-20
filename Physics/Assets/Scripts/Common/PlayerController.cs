using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputHandler playerInputHandler;
    public float moveSpeed;
    public float angularSpeed;

    public float jumpForce;
    public ForceMode forceMode;

    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerInputHandler.onJumpEvent.AddListener(Jump);
    }

    private void OnDisable()
    {
        playerInputHandler.onJumpEvent.RemoveListener(Jump);
    }

    void Update()
    {
        Vector2 moveDirection = playerInputHandler.GetMoveDirection();
        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        m_Rigidbody.AddForce(transform.up * jumpForce, forceMode);
    }
}
