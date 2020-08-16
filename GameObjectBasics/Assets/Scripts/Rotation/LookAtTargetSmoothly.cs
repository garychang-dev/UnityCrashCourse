using UnityEngine;

public class LookAtTargetSmoothly : MonoBehaviour
{
    public Transform target;
    public float angularSpeed;
    //public float rotationSmoothing;

    public float slowAngle;
    public float arrivalAngle;
    private Quaternion desiredRotation;

    // When your object's transform depends on another's object,
    // use LateUpdate to ensure the other object already finished moving!
    private void LateUpdate()
    {
        /*
         * Attempt 1: Set transform.rotation with desired rotation
         * The object's rotation speed is uncapped. It does not look very nice.
         */

        //Vector3 direction = target.position - transform.position;
        //Quaternion desiredRotation = Quaternion.LookRotation(direction, transform.up);
        //transform.rotation = desiredRotation;

        /*
         * Attempt 1 alternate: Simply make the object stare at the target using LookAt() function.
         */

        //transform.LookAt(target);

        /*
         * Attempt 2: Try to cap the rotation speed
         * Object stops its rotation abruptly when target rotation is reached
         */

        //Vector3 direction = target.position - transform.position;
        //desiredRotation = Quaternion.LookRotation(direction, transform.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * Time.deltaTime);

        /*
         * Attempt 3: Rotate and smoothly arrive at desired rotation
         * "rotationSmoothing" is a value between 0 and 1
         */

        //Vector3 direction = target.position - transform.position;
        //desiredRotation = Quaternion.LookRotation(direction, transform.up);
        //transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothing);

        /*
         * Attempt 4: Rotate at full speed, then slow down when the target angle is near, then stop completely when it is close enough
         * This produces the best result
         */
        Vector3 direction = target.position - transform.position;
        desiredRotation = Quaternion.LookRotation(direction, transform.up);

        float angleDiff = Mathf.Abs(Quaternion.Angle(transform.rotation, desiredRotation));
        if (angleDiff > slowAngle)
        {
            // Rotate at full speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * Time.deltaTime);
        }
        else if (angleDiff > arrivalAngle)
        {
            // Rotate at slower speed
            float percentSpeed = angleDiff / (slowAngle - arrivalAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, angularSpeed * percentSpeed * Time.deltaTime);
        }
    }
}
