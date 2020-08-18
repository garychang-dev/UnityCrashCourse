using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLogger : MonoBehaviour
{
    public PlayerInputHandler playerInput;

    void Start()
    {
        playerInput.onJumpEvent.AddListener(OnJumpEvent);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = playerInput.GetMoveDirection();
        Vector2 lookDirection = playerInput.GetLookDirection();

        if (moveDirection != Vector2.zero)
        {
            Debug.Log($"MoveDirection: {moveDirection}");
        }

        if (lookDirection != Vector2.zero)
        {
            Debug.Log($"LookDirection: {lookDirection}");
        }
    }


    private void OnJumpEvent()
    {
        Debug.Log("Jump!");
    }
}
