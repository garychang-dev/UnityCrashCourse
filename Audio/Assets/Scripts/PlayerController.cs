using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotateSpeed;
    public float jumpForce;

    private Rigidbody m_Rigidbody;
    private Vector3 m_MoveDirection;
    private Transform m_VerticalLook;
    private Vector3 m_EulerAngles;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_VerticalLook = transform.Find("LookUpDown");
    }

    public void Move(Vector3 direction)
    {
        m_MoveDirection = direction;
    }

    public void Rotate(Vector2 look)
    {
        // Horizontal rotation
        transform.Rotate(transform.up, look.x * rotateSpeed * Time.deltaTime);

        // Vertical rotation
        m_EulerAngles.x = Mathf.Clamp(m_EulerAngles.x - look.y * rotateSpeed * Time.deltaTime, -89f, 89f);
        m_VerticalLook.transform.localEulerAngles = m_EulerAngles;
    }

    public void FixedUpdate()
    {
        // Update position using rigidbody
        Vector3 worldSpaceDirection = transform.TransformDirection(m_MoveDirection);
        m_Rigidbody.MovePosition(m_Rigidbody.position + (worldSpaceDirection * speed * Time.deltaTime));
    }

    public void Jump()
    {
        // For simplicity, simply add forces to the rigidbody directly
        m_Rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        AudioManager.instance.Play("Jump");
    }

    public Vector3 GetMoveDirection()
    {
        return m_MoveDirection;
    }
}
