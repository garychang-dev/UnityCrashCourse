using UnityEngine;

public class PatrollerVision : MonoBehaviour
{
    public float viewDistance;
    public float viewAngle;
    public LayerMask layerMask;

    private Transform m_PlayerTransform;

    void Start()
    {
        // Obtain the player's transform component
        // NOTE: The player has a "Player" tag!
        GameObject player = GameObject.FindGameObjectWithTag(Constants.PLAYER_TAG);
        m_PlayerTransform = player.transform;
    }

    public bool IsPlayerInVision()
    {
        Vector3 toPlayerVector = m_PlayerTransform.position - transform.position;
        float distanceFromPlayer = toPlayerVector.magnitude;

        // Is player within view distance?
        if (distanceFromPlayer < viewDistance)
        {
            // Is player within view angle?
            // Check the difference between forward and "direction to player" vectors
            float angle = Vector3.Angle(transform.forward, toPlayerVector);
            if (angle < (viewAngle / 2))
            {
                // Is player in line of sight?
                // Do a raycast and use the layer mask
                RaycastHit hitInfo;
                if (Physics.Raycast(transform.position, toPlayerVector, out hitInfo, viewDistance, layerMask))
                {
                    if (hitInfo.collider.gameObject.tag == Constants.PLAYER_TAG)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
