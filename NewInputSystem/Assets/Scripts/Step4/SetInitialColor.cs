using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetInitialColor : MonoBehaviour
{
    void Start()
    {
        // Get player index from PlayerInput component
        var playerIndex = GetComponent<PlayerInput>().playerIndex;

        // Get color assigned to our current player index
        
        var playerColors = FindObjectOfType<PlayerColors>();
        var myMaterial = playerColors.colors
            .FirstOrDefault(c => c.playerIndex == playerIndex)
            .material;

        // Assign material to MeshRenderer material
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = myMaterial;
    }
}
