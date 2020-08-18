using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float speedMultiplier;

    void Update()
    {
        bool isSpeedBoost = Keyboard.current.shiftKey.isPressed;
        
        Vector3 direction = Vector3.zero;
        // Forward and backward
        if (Keyboard.current.wKey.isPressed)
        {
            direction.z += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction.z -= 1;
        }

        // Left and right
        if (Keyboard.current.aKey.isPressed)
        {
            direction.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x += 1;
        }

        // Up and down
        if (Keyboard.current.qKey.isPressed)
        {
            direction.y -= 1;
        }
        if (Keyboard.current.eKey.isPressed)
        {
            direction.y += 1;
        }

        float moveSpeed = isSpeedBoost ? speed * speedMultiplier : speed;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
