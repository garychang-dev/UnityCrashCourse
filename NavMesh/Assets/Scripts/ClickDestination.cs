using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickDestination : MonoBehaviour
{
    private NavMeshAgent m_Agent;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // NOTE: Use a key or button that is convenient to you
        // Keyboard.current.spaceKey.wasPressedThisFrame

        // NOTE 2: If you wish to use the old Input Manager instead of the new Input System,
        //         you can use the commented code below and disable the rest
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit, 100.0f))
        //     {
        //         m_Agent.SetDestination(hit.point);
        //     }
        // }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Get mouse position in screen space
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mousePosition = mouseScreenPosition;

            // Perform a raycast in world space and check what the ray hits
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePosition), out hit, 100f))
            {
                // Set destination for NavMeshAgent
                m_Agent.SetDestination(hit.point);
            }
        }
    }
}
