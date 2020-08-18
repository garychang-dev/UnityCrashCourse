using UnityEngine;

public class ToggleWaypointScript : MonoBehaviour
{
    public bool reactOnCollision;
    public bool reactOnTrigger;

    private FollowWaypoints m_Component;

    void Start()
    {
        m_Component = GetComponent<FollowWaypoints>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (reactOnCollision && collision.gameObject.tag == "Player")
        {
            m_Component.enabled = !m_Component.enabled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (reactOnTrigger && other.tag == "Player")
        {
            m_Component.enabled = !m_Component.enabled;
        }
    }
}
