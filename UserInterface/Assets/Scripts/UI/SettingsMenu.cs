using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct SettingsData
{
    public int difficulty;
    public float soundVolume;
    public float musicVolume;
    public string playerName;
}

public class SettingsMenu : MonoBehaviour
{
    int difficulty;
    float soundVolume;
    float musicVolume;
    string playerName;

    // Reference to the UI elements that contain the values
    [SerializeField] private TMP_Dropdown difficultyDropdown;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TMP_InputField playerNameInput;

    void OnEnable()
    {
        LoadData();
    }

    public void OnDifficultyChanged(int index)
    {
        Debug.Log($"OnDifficultyChanged: {index}");
        difficulty = index;
    }

    public void OnSoundVolumeChanged(float volume)
    {
        Debug.Log($"OnSoundVolumeChanged: {volume}");
        soundVolume = volume;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        Debug.Log($"OnMusicVolumeChanged: {volume}");
        musicVolume = volume;
    }

    public void OnNameValueChanged(string currentValue)
    {
        Debug.Log($"OnNameValueChanged: {currentValue}");
    }

    public void OnNameEndEdit(string currentValue)
    {
        Debug.Log($"OnNameEndEdit: {currentValue}");
        playerName = currentValue;
    }

    public void OnNameSelect(string currentValue)
    {
        Debug.Log($"OnNameSelect: {currentValue}");
    }
    public void OnNameDeselect(string currentValue)
    {
        Debug.Log($"OnNameDeselect: {currentValue}");
    }

    public void OnSaveClicked()
    {
        SettingsData data;
        data.difficulty = difficulty;
        data.soundVolume = soundVolume;
        data.musicVolume = musicVolume;
        data.playerName = playerName;

        GameSettings.instance.SaveData(data);
    }

    private void LoadData()
    {
        SettingsData data = GameSettings.instance.LoadData();
        difficulty = data.difficulty;
        soundVolume = data.soundVolume;
        musicVolume = data.musicVolume;
        playerName = data.playerName;

        difficultyDropdown.value = difficulty;
        soundSlider.value = soundVolume;
        musicSlider.value = musicVolume;
        playerNameInput.text = playerName;
    }
}
