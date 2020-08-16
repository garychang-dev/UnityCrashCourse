using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateToTarget : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float arrivalDistance = 0.1f;

    void Update()
    {
        /*
         * Attempt 1: Simply translate towards the target's position
         * The object continuously trembles at the destination
         */

        //Vector3 direction = target.position - transform.position;
        //transform.Translate(direction.normalized * speed * Time.deltaTime);

        /*
         * Attempt 2: Translate towards the target, but stop moving when close enough
         */

        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > arrivalDistance)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
