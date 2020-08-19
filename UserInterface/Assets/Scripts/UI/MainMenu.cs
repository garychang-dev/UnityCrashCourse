using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public UnityEvent onSettingsClickEvent;
    public int sceneIndexToLoad;

    public void OnStartButtonClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void OnSettingsButtonClick()
    {
        onSettingsClickEvent.Invoke();
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
