using UnityEngine;
using UnityEngine.AI;

public class TouchPlayerController : MonoBehaviour
{
    private PlayerControls m_PlayerControls;
    private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_PlayerControls = GetComponent<PlayerControls>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        m_PlayerControls.onTouchEvent.AddListener(Touch);
    }

    private void OnDisable()
    {
        m_PlayerControls.onTouchEvent.RemoveListener(Touch);
    }

    private void Touch(Vector2 screenPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(screenPosition), out hit, 100f))
        {
            m_Agent.SetDestination(hit.point);
        }
    }
}
