using UnityEngine;

public class Translate : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public Space space;

    void Update()
    {
        /*
         * Attempt 1: Translate using direction only.
         * Results are terrible! Large vector magnitude makes the object move too fast.
         */

        //transform.Translate(direction);

        /*
         * Attempt 2: Translate with (normalized direction * speed). Looks good, but dependent on frame rate.
         */

        //transform.Translate(direction.normalized * speed);

        /*
         * Attempt 3: Normalized vector multiplied by speed and delta time.
         * Object moves at desired speed and is dependent on time instead of frame rate.
         */

        //transform.Translate(direction.normalized * speed * Time.deltaTime);

        /*
         * Attempt 4: Specify which space to translate on
         */
        transform.Translate(direction.normalized * speed * Time.deltaTime, space);
    }
}
