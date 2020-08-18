using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandlerV2 : MonoBehaviour
{
    public UnityEvent onJumpEvent;

    private Vector2 m_moveDirection;
    private Vector2 m_lookDirection;
    //private PlayerInputActions m_PlayerInputActions;


    
    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        int playerIndex = playerInput.playerIndex;

        // Assign this instance to the player controller that has the matching player index
        var allPlayerControllers = FindObjectsOfType<PlayerControllerV2>();
        var playerController = allPlayerControllers.FirstOrDefault(p => p.playerIndex == playerIndex);
        playerController.SetPlayerInputHandler(this);

        //m_PlayerInputActions = new PlayerInputActions();
    }

    //private void OnEnable()
    //{
    //    m_PlayerInputActions.Enable();
    //    m_PlayerInputActions.Player.Jump.performed += OnJump;
    //}

    //private void OnDisable()
    //{
    //    m_PlayerInputActions.Player.Jump.performed -= OnJump;
    //    m_PlayerInputActions.Disable();
    //}

    //void Update()
    //{
    //    m_moveDirection = m_PlayerInputActions.Player.Move.ReadValue<Vector2>();
    //    m_lookDirection = m_PlayerInputActions.Player.Look.ReadValue<Vector2>();
    //}

    public void OnMove(InputAction.CallbackContext ctx)
    {
        m_moveDirection = ctx.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        m_lookDirection = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            onJumpEvent.Invoke();
        }
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
