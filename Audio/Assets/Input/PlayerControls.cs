using UnityEngine;
using UnityEngine.InputSystem;

// PlayerControls class is an abstraction layer that reads the user input
// and informs the player controller what is happening
public class PlayerControls : MonoBehaviour
{
    private Controls m_Controls;

    private PlayerController m_PlayerController;
    void Awake()
    {
        m_Controls = new Controls();
        m_PlayerController = GetComponent<PlayerController>();

        // Action Type: Action Asset
        m_Controls.Player.Jump.started += OnJump;
    }

    void OnEnable()
    {
        m_Controls.Enable();
    }

    void OnDisable()
    {
        m_Controls.Disable();
    }
    
    void Update()
    {
        // Action Type: Value
        Vector2 inputDirection = m_Controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        Vector2 look = m_Controls.Player.Look.ReadValue<Vector2>();

        // Set the direction vector in player controller
        m_PlayerController.Move(direction);
        m_PlayerController.Rotate(look);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        m_PlayerController.Jump();
    }
}
