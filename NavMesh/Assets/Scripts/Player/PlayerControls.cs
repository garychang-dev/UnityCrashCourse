using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
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
    }

    void OnDisable()
    {
        m_Controls.Disable();
    }

    void Update()
    {
        Vector2 inputDirection = m_Controls.Player.Move.ReadValue<Vector2>();
        Vector3 direction = new Vector3(inputDirection.x, 0f, inputDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);

        // Set the direction vector in player controller
        m_PlayerController.Move(direction);
    }
}
