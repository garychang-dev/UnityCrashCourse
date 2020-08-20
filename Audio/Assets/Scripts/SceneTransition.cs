using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public void LoadUISoundTestScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Load3DSoundTestScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
