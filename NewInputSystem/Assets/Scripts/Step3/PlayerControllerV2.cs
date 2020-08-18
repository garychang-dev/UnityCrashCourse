using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    public float moveSpeed;
    public int playerIndex;

    private PlayerInputHandlerV2 m_PlayerInputHandler;

    public void SetPlayerInputHandler(PlayerInputHandlerV2 handler)
    {
        m_PlayerInputHandler = handler;
        m_PlayerInputHandler.onJumpEvent.AddListener(Jump);
    }

    private void Update()
    {
        if (m_PlayerInputHandler != null)
        {
            Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
            Move(moveDirection);
        }
    }

    private void Move(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        Debug.Log($"Player {playerIndex} Jump!");
    }
}
