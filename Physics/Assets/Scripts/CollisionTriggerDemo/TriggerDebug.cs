using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDebug : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter: \"{gameObject.name}\" and \"{other.gameObject.name}\"");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log($"OnTriggerStay: \"{gameObject.name}\" and \"{other.gameObject.name}\"");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"OnTriggerExit: \"{gameObject.name}\" and \"{other.gameObject.name}\"");
    }
}
