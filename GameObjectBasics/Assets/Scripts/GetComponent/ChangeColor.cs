using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColorToApply;

    private List<MeshRenderer> m_MeshRenderers;

    void Start()
    {
        m_MeshRenderers = new List<MeshRenderer>();

        var meshRenderer = GetComponent<MeshRenderer>();
        var meshRenderersInChildren = GetComponentsInChildren<MeshRenderer>();

        m_MeshRenderers.Add(meshRenderer);
        m_MeshRenderers.AddRange(meshRenderersInChildren);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_MeshRenderers.ForEach(m => m.material.color = newColorToApply);
        }
    }
}
