using UnityEngine;

// This proxy is being used because the UI elements (buttons) cannot bind directly to the Audio Manager.
// After changing scenes and returning to the UI Sound Test scene, the Audio Manager from the scene is destroyed and the bindings are no longer valid.
// Instead, the singleton that was created originally replaces it, but no UI elements are bound to it anymore.

public class AudioManagerProxy : MonoBehaviour
{
    public void Play(string name)
    {
        AudioManager.instance.Play(name);
    }

    public void Stop(string name)
    {
        AudioManager.instance.Stop(name);
    }
}
