using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent onJumpEvent;
    public UnityEvent onShootEvent;

    private Vector2 m_MoveDirection;
    
    private PlayerInputActions m_PlayerInputActions;

    void Awake()
    {
        m_PlayerInputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        m_PlayerInputActions.Enable();
        m_PlayerInputActions.Player.Jump.performed += OnJump;
        m_PlayerInputActions.Player.Shoot.performed += OnShoot;
    }

    void OnDisable()
    {
        m_PlayerInputActions.Disable();
        m_PlayerInputActions.Player.Jump.performed -= OnJump;
        m_PlayerInputActions.Player.Shoot.performed -= OnShoot;
    }

    private void Update()
    {
        m_MoveDirection = m_PlayerInputActions.Player.Move.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        onJumpEvent?.Invoke();
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        onShootEvent?.Invoke();
    }

    public Vector2 GetMoveDirection()
    {
        return m_MoveDirection;
    }
}
