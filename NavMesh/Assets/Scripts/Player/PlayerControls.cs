using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public UnityEvent<Vector2> onTouchEvent;

    private InputActions m_Controls;

    private Vector2 m_Direction;

    void Awake()
    {
        m_Controls = new InputActions();
    }

    void OnEnable()
    {
        m_Controls.Enable();
        m_Controls.Player.Touch.performed += Touch;
    }

    void OnDisable()
    {
        m_Controls.Disable();
        m_Controls.Player.Touch.performed -= Touch;
    }

    void Update()
    {
        m_Direction = m_Controls.Player.Move.ReadValue<Vector2>();
    }

    void Touch(InputAction.CallbackContext ctx)
    {
        Vector2 screenLocation = ctx.ReadValue<Vector2>();
        onTouchEvent?.Invoke(screenLocation);
    }

    public Vector2 GetMoveDirection()
    {
        return m_Direction;
    }
}
