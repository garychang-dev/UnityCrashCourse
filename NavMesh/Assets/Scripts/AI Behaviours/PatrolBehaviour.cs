using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PatrolBehaviour : MonoBehaviour
{
    public delegate void PlayerFoundEvent();
    public event PlayerFoundEvent OnPlayerFoundEvent;

    public float moveSpeed = 2f;
    public float angularSpeed = 270f;

    [SerializeField]
    private Vector3 m_CurrentWaypoint;
    private List<Vector3> m_Waypoints;
    private NavMeshAgent m_Agent;
    private PatrollerVision m_Vision;

    void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Vision = GetComponent<PatrollerVision>();
    }

    void Start()
    {
        m_Waypoints = new List<Vector3>();
        SetupWaypoints();
        SelectRandomWaypoint();
    }

    private void OnEnable()
    {
        m_Agent.speed = moveSpeed;
        m_Agent.angularSpeed = angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Select another waypoint when agent arrives at selected one
        // HINT: Use a large "arrival distance" (e.g. 1) if the agent has trouble reaching it

        // TODO: If player is found, trigger the event!

    }

    private void SetupWaypoints()
    {
        // TODO: Get a reference to all waypoints' positions
        // HINT: We have a Waypoint tag
    }

    private void SelectRandomWaypoint()
    {
        // TODO: Select a random waypoint and set it as the agent's destination
    }
}
