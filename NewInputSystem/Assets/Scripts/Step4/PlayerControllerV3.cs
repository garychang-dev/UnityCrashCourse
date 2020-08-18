using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV3 : MonoBehaviour
{
    public float moveSpeed;

    private PlayerInputHandlerV3 m_PlayerInputHandler;
    private PlayerInput m_PlayerInput;

    private void Awake()
    {
        m_PlayerInputHandler = GetComponent<PlayerInputHandlerV3>();
        m_PlayerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        m_PlayerInputHandler.onJumpEvent.AddListener(Jump);
    }

    private void OnDisable()
    {
        m_PlayerInputHandler.onJumpEvent.RemoveListener(Jump);
    }

    private void Update()
    {
        if (m_PlayerInputHandler != null)
        {
            Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
            Move(moveDirection);
        }
    }

    private void Move(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log($"Player {m_PlayerInput.playerIndex} Jump!");
    }
}
