using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISounds : MonoBehaviour
{
    public AudioSource[] soundClips;

    public AudioSource[] musicClips;

    public void PlaySound(int index)
    {
        soundClips[index].Play();
    }

    public void PlayMusic(int index)
    {
        musicClips[index].Play();
    }    
}
