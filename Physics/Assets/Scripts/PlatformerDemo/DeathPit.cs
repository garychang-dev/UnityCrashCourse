using UnityEngine;
using UnityEngine.Events;

public class DeathPit : MonoBehaviour
{
    public UnityEvent onDeathEvent;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onDeathEvent?.Invoke();
        }
    }
}
