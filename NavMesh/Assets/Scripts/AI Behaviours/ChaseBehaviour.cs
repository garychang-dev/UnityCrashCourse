using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : MonoBehaviour
{
    public delegate void PlayerLostEvent();
    public event PlayerLostEvent OnPlayerLostEvent;

    public float moveSpeed = 5f;
    public float angularSpeed = 360f;
    public float timeUntilPlayerLost = 5f;

    public GameObject alertLights; // Assigned in Editor
    private GameObject m_Player;
    private NavMeshAgent m_Agent;
    private PatrollerVision m_Vision;

    private static float s_PlayerLostTime;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        m_Agent = GetComponent<NavMeshAgent>();
        m_Vision = GetComponent<PatrollerVision>();
    }

    private void OnEnable()
    {
        m_Agent.speed = moveSpeed;
        m_Agent.angularSpeed = angularSpeed;
        alertLights.SetActive(true);
        s_PlayerLostTime = Time.time + timeUntilPlayerLost;
    }

    private void OnDisable()
    {
        alertLights.SetActive(false);
    }

    void Update()
    {
        // TODO: Continuously chase the player

        // TODO: If the player is being seen, delay the time when the player will be lost

        // TODO: If the patroller did not see its target for a while, trigger an event!
    }
}
