using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputHandler playerInputHandler;
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = playerInputHandler.GetMoveDirection();
        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
