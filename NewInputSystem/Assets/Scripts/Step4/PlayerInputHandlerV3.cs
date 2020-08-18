using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputHandlerV3 : MonoBehaviour
{
    public UnityEvent onJumpEvent;

    private Vector2 m_moveDirection;
    private Vector2 m_lookDirection;

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
        if (ctx.performed && onJumpEvent != null)
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
