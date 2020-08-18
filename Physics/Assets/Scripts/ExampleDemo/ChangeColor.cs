using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject target;
    public Color color;

    private Color m_OriginalColor;
    private MeshRenderer m_TargetMeshRenderer;

    private void Start()
    {
        m_TargetMeshRenderer = target.GetComponent<MeshRenderer>();
        m_OriginalColor = m_TargetMeshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_TargetMeshRenderer.material.color = color;
    }

    private void OnTriggerExit(Collider other)
    {
        m_TargetMeshRenderer.material.color = m_OriginalColor;
    }
}
