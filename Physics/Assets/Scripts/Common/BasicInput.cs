using UnityEngine;
using UnityEngine.InputSystem;

public static class BasicInput
{
    public static Vector3 GetInputDirection(bool clamped = false)
    {
        Vector3 direction = Vector3.zero;

        if (Keyboard.current.aKey.isPressed)
        {
            direction.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction.x += 1;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            direction.z += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction.z -= 1;
        }

        return clamped ? Vector3.ClampMagnitude(direction, 1f) : direction;
    }
}
