using UnityEngine;

public class TransformTranslate : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Vector3 direction = BasicInput.GetInputDirection(true);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
