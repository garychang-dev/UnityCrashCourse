using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public float angularSpeed;

    // When your object's transform depends on another's object,
    // use LateUpdate to ensure the other object already finished moving!
    private void LateUpdate()
    {
        /*
         * Attempt 1: Set transform.rotation with desired rotation
         * The object's rotation speed is uncapped. It does not look very nice.
         */

        //Vector3 direction = target.position - transform.position;
        //Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
        //transform.rotation = desiredRotation;

        /*
         * Attempt 1 alternate: Simply make the object stare at the target using LookAt() function.
         */

        //transform.LookAt(target);

        /*
         * Attempt 2: Try to cap the rotation speed
         * Object stops its rotation abruptly when target rotation is reached
         */

        Vector3 direction = target.position - transform.position;
        Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * Time.deltaTime);
    }
}
