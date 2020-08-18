using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDebug : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollisionEnter: \"{gameObject.name}\" and \"{collision.gameObject.name}\"");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log($"OnCollisionStay: \"{gameObject.name}\" and \"{collision.gameObject.name}\"");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log($"OnCollisionExit: \"{gameObject.name}\" and \"{collision.gameObject.name}\"");
    }
}
