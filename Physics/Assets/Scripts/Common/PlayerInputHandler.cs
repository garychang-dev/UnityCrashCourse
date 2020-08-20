using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent onJumpEvent;

    private Vector2 m_moveDirection;
    private Vector2 m_lookDirection;
    private PlayerInputActions m_PlayerInputActions;

    private void Awake()
    {
        m_PlayerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        m_PlayerInputActions.Enable();
        m_PlayerInputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        m_PlayerInputActions.Player.Jump.performed -= OnJump;
        m_PlayerInputActions.Disable();
    }

    void Update()
    {
        m_moveDirection = m_PlayerInputActions.Player.Move.ReadValue<Vector2>();
        m_lookDirection = m_PlayerInputActions.Player.Look.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        onJumpEvent.Invoke();
    }

    public Vector2 GetMoveDirection()
    {
        return m_moveDirection;
    }

    public Vector2 GetLookDirection()
    {
        return m_lookDirection;
    }
}
