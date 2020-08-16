using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateToTargetSmoothly : MonoBehaviour
{
    public Transform target;
    public float speed;
    //public float translationSmoothing;

    public float slowDistance;
    public float arrivalDistance;
    

    void Update()
    {
        /*
         * Attempt 1: Bounces back and forth around the target
         */

        //Vector3 direction = target.position - transform.position;
        //transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);

        /*
         * Attempt 2: Translate towards the target, but stop moving when close enough
         */

        //Vector3 direction = target.position - transform.position;
        //if (direction.magnitude > arrivalDistance)
        //{
        //    transform.Translate(direction.normalized * speed * Time.deltaTime);
        //}

        /*
        * Attempt 3: Use Lerp to smoothly arrive to the target position.
        * Arrives to target too slowly.
        * WARNING: Vector3.Lerp() is not being used as intended. This can cause undesired results if the target is moving.
        */

        //transform.position = Vector3.Lerp(transform.position, target.transform.position, translationSmoothing);
    }

    private void LateUpdate()
    {
        /*
         * Attempt 4: Move at full speed, then slow down when the target is near, then stop completely when it is close enough
         * So far, this shows the best result but requires some vector math!
         */

        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance > slowDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
        else if (distance > arrivalDistance)
        {
            float percentage = (distance - arrivalDistance) / (slowDistance - arrivalDistance);
            transform.Translate(direction.normalized * speed * percentage * Time.deltaTime, Space.World);
        }
    }
}
