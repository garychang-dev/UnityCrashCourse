using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]
public class BoolUnityEvent : UnityEvent<bool> { }

public class PlayerInputHandler : MonoBehaviour
{
    public UnityEvent onJumpEvent;
    public UnityEvent onAttackEvent;
    public BoolUnityEvent onBlockEvent;

    private Vector2 m_MoveDirection;
    private Vector2 m_LookDirection;
    
    private PlayerInputActions m_PlayerInputActions;

    void Awake()
    {
        m_PlayerInputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        m_PlayerInputActions.Enable();
        m_PlayerInputActions.Player.Jump.performed += OnJump;
        m_PlayerInputActions.Player.Attack.performed += OnAttack;

        m_PlayerInputActions.Player.Block.started += OnBlockStarted;
        m_PlayerInputActions.Player.Block.canceled += OnBlockCanceled;
    }

    void OnDisable()
    {
        m_PlayerInputActions.Disable();
        m_PlayerInputActions.Player.Jump.performed -= OnJump;
        m_PlayerInputActions.Player.Attack.performed -= OnAttack;

        m_PlayerInputActions.Player.Block.started -= OnBlockStarted;
        m_PlayerInputActions.Player.Block.canceled -= OnBlockCanceled;
    }

    private void Update()
    {
        m_MoveDirection = m_PlayerInputActions.Player.Move.ReadValue<Vector2>();
        m_LookDirection = m_PlayerInputActions.Player.Look.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        onJumpEvent?.Invoke();
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        onAttackEvent?.Invoke();
    }

    public void OnBlockStarted(InputAction.CallbackContext ctx)
    {
        onBlockEvent?.Invoke(true);
    }

    public void OnBlockCanceled(InputAction.CallbackContext ctx)
    {
        onBlockEvent?.Invoke(false);
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
