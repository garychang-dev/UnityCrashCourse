using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class demonstrates that we can Find other game objects by name or tags.
// From these objects, we can directly access components and do modifications or call functions.
public class GlobalObjectManager : MonoBehaviour
{
    List<GameObject> cubeHeads;
    PlayerDebug player;

    void Start()
    {
        cubeHeads = new List<GameObject>();
        cubeHeads.AddRange(GameObject.FindGameObjectsWithTag("CubeHead"));
        player = GameObject.Find("PlayerCube")?.GetComponent<PlayerDebug>();
    }

    void Update()
    {
        // Destroy the cube heads
        if (Input.GetKeyDown(KeyCode.Z))
        {
            cubeHeads.ForEach(delegate (GameObject obj) {
                Destroy(obj);
            });
            cubeHeads.Clear();
        }

        // Change the cube heads to green
        if (Input.GetKeyDown(KeyCode.X))
        {
            cubeHeads.ForEach(delegate (GameObject obj) {
                MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
                meshRenderer.material.color = Color.green;
            });
        }

        // Function call on some object component
        if (Input.GetKeyDown(KeyCode.C) && player != null)
        {
            player.SayHello();
        }
    }
}
