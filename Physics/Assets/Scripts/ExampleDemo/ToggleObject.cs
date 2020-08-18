using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.SetActive(!target.activeSelf);
        }
    }
}
