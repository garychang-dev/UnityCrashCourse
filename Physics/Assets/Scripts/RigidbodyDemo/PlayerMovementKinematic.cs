using UnityEngine;

public class PlayerMovementKinematic : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 direction = Vector3.ClampMagnitude(BasicInput.GetInputDirection(), 1f);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
