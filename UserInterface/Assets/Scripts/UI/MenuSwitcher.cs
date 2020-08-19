using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public void ActivateMainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ActivateSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
