using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent onJumpEvent;

    private Vector2 m_MoveDirection;
    private Vector2 m_LookDirection;
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
        m_MoveDirection = m_PlayerInputActions.Player.Move.ReadValue<Vector2>();
        m_LookDirection = m_PlayerInputActions.Player.Look.ReadValue<Vector2>();
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        onJumpEvent.Invoke();
    }

    public Vector2 GetMoveDirection()
    {
        return m_MoveDirection;
    }

    public Vector2 GetLookDirection()
    {
        return m_LookDirection;
    }
}
