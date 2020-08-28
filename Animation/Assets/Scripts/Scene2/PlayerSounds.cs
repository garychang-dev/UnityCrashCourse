using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource stepSound;
    public AudioSource jumpSound;

    public void PlayStepSound()
    {
        stepSound.Play();
    }
    public void PlayJumpSound()
    {
        jumpSound.Play();
    }
}
