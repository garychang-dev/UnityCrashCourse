using UnityEngine;

public class PatrollerController : MonoBehaviour
{
    // Behaviours
    private PatrolBehaviour patrolBehaviour;
    private ChaseBehaviour chaseBehaviour;

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
        // Alert all patrollers and change modes
        GameObject[] allPatrollers = GameObject.FindGameObjectsWithTag(Constants.PATROLLER_TAG);
        foreach (var obj in allPatrollers)
        {
            PatrollerController controller = obj.GetComponent<PatrollerController>();
            controller.SwitchToChaseMode();
        }
    }

    public void PlayerLost()
    {
        // Signal all patrollers and change modes
        GameObject[] allPatrollers = GameObject.FindGameObjectsWithTag(Constants.PATROLLER_TAG);
        foreach (var obj in allPatrollers)
        {
            PatrollerController controller = obj.GetComponent<PatrollerController>();
            controller.SwitchToPatrolMode();
        }
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
