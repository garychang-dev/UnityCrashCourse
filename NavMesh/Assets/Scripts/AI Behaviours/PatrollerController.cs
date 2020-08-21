using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrollerController : MonoBehaviour
{
    // Behaviours
    PatrolBehaviour patrolBehaviour;
    ChaseBehaviour chaseBehaviour;

    private void Awake()
    {
        patrolBehaviour = GetComponent<PatrolBehaviour>();
        chaseBehaviour = GetComponent<ChaseBehaviour>();

        SwitchToPatrolMode();
    }

    private void OnEnable()
    {
        patrolBehaviour.OnPlayerFoundEvent += PlayerFound;
        chaseBehaviour.OnPlayerLostEvent += PlayerLost;
    }

    private void OnDisable()
    {
        patrolBehaviour.OnPlayerFoundEvent -= PlayerFound;
        chaseBehaviour.OnPlayerLostEvent -= PlayerLost;
    }

    public void PlayerFound()
    {
        // TODO: Alert all patrollers and change modes
    }

    public void PlayerLost()
    {
        // TODO: Signal all patrollers and change modes
    }

    public void SwitchToChaseMode()
    {
        patrolBehaviour.enabled = false;
        chaseBehaviour.enabled = true;
    }

    public void SwitchToPatrolMode()
    {
        patrolBehaviour.enabled = true;
        chaseBehaviour.enabled = false;
    }
}
