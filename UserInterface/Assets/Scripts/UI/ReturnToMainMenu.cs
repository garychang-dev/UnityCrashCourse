using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMainMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
