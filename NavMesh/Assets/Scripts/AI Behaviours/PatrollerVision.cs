using UnityEngine;

public class PatrollerVision : MonoBehaviour
{
    public float viewDistance;
    public float viewAngle;
    public LayerMask layerMask;

    private Transform m_PlayerTransform;

    void Start()
    {
        // TODO: Obtain the player's transform component
        // HINT: The player has a "Player" tag!
    }

    public bool IsPlayerInVision()
    {
        Vector3 toPlayerVector = m_PlayerTransform.position - transform.position;
        float distanceFromPlayer = toPlayerVector.magnitude;

        // TODO: Is player within view distance?
        
        // TODO: Is player within view angle?
        // HINT: Check the difference between forward and "direction to player" vectors
            
        // TODO: Is player in line of sight?
        // HINT: Do a raycast and use the layer mask
        
        return false;
    }
}
