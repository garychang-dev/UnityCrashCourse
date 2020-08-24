using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public bool touched = false;

    private InputActions m_Controls;

    private PlayerController m_PlayerController;
    void Awake()
    {
        m_Controls = new InputActions();
        m_PlayerController = GetComponent<PlayerController>();
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
        Vector2 inputDirection = m_Controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        // Set the direction vector in player controller
        m_PlayerController.Move(direction);
    }

    void Touch(InputAction.CallbackContext ctx)
    {
        Vector2 screenLocation = ctx.ReadValue<Vector2>();
        
    }
}
