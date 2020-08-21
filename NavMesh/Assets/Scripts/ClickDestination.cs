using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickDestination : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // NOTE: Use a key or button that is convenient to you
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // TODO: Get mouse position in screen space
            // TODO: Perform a raycast in world space and check what the ray hits
            // TODO: Set destination for NavMeshAgent
        }
    }
}
