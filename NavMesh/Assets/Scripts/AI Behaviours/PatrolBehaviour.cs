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

        m_Waypoints = new List<Vector3>();
        SetupWaypoints();
    }

    private void OnEnable()
    {
        m_Agent.speed = moveSpeed;
        m_Agent.angularSpeed = angularSpeed;

        SelectRandomWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        // Select another waypoint when agent arrives at selected one
        // Use a large "arrival distance" (e.g. 1) if the agent has trouble reaching it
        if (m_Agent.remainingDistance < Constants.ARRIVAL_DISTANCE)
        {
            SelectRandomWaypoint();
        }

        // If player is found, trigger the event!
        bool isPlayerFound = m_Vision.IsPlayerInVision();
        if (isPlayerFound)
        {
            OnPlayerFoundEvent?.Invoke();
        }
    }

    private void SetupWaypoints()
    {
        // Get a reference to all waypoints' positions
        // NOTE: We have a Waypoint tag
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag(Constants.WAYPOINT_TAG);
        foreach (var wp in waypoints)
        {
            m_Waypoints.Add(wp.transform.position);
        }
        
    }

    private void SelectRandomWaypoint()
    {
        // Select a random waypoint and set it as the agent's destination
        int randomIndex = Random.Range(0, m_Waypoints.Count);
        m_CurrentWaypoint = m_Waypoints[randomIndex];
        m_Agent.SetDestination(m_CurrentWaypoint);
    }
}
