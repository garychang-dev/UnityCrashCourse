using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Vector3 m_Direction;
    private Rigidbody m_Rigidbody;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        m_Direction = direction;
    }

    public void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Direction * speed * Time.fixedDeltaTime);
    }
}
