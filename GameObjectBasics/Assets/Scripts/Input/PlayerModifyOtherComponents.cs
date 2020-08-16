using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerModifyOtherComponents : MonoBehaviour
{
    private PlayerMovement playerInput;
    private Light spotlight;

    void Start()
    {
        playerInput = GetComponent<PlayerMovement>();
        spotlight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // Speed up
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            playerInput.speed += 1;
        }

        // Speed down
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            playerInput.speed -= 1;
        }

        // Toggle the lights
        if(Input.GetKeyDown(KeyCode.L))
        {
            spotlight.enabled = !spotlight.enabled;
        }
    }
}
