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
        //Keyboard.current.spaceKey.wasPressedThisFrame

#if UNITY_ANDROID
        // This code section is only for Android builds

        if (Touchscreen.current.primaryTouch.tap.wasPressedThisFrame)
        {
            Vector3 position = Touchscreen.current.primaryTouch.position.ReadValue();
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit, 100f))
            {
                // Set destination for NavMeshAgent
                m_Agent.SetDestination(hit.point);
            }
        }

#else
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
#endif
    }
}
