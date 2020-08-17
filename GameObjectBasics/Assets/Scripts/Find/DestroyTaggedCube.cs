using UnityEngine;

public class DestroyTaggedCube : MonoBehaviour
{
    public string tagNameToDestroy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tagNameToDestroy);
            foreach(var obj in objects)
            {
                Destroy(obj);
            }
        }
    }
}
