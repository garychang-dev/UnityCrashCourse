using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

struct TransformData
{
    public Vector3 position;
    public Quaternion rotation;
}

public class ResetEverything : MonoBehaviour
{
    List<GameObject> demoObjects;
    Dictionary<GameObject, TransformData> originalTransforms;

    const string COLLIDERS_TAG_NAME = "Colliders";

    void Start()
    {
        originalTransforms = new Dictionary<GameObject, TransformData>();
        demoObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(COLLIDERS_TAG_NAME));
        foreach (var demoObject in demoObjects)
        {
            TransformData data;
            data.position = demoObject.transform.position;
            data.rotation = demoObject.transform.rotation;
            originalTransforms.Add(demoObject, data);
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            foreach (var demoObject in demoObjects)
            {
                if (originalTransforms.TryGetValue(demoObject, out TransformData data))
                {
                    // Restore position and rotation
                    demoObject.transform.position = data.position;
                    demoObject.transform.rotation = data.rotation;

                    // Reset rigidbody velocities
                    Rigidbody rb = demoObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity = Vector3.zero;
                        rb.angularVelocity = Vector3.zero;
                    }
                }
            }
        }
    }
}
