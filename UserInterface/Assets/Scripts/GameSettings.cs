using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Singleton
    public static GameSettings instance;

    // Local memory
    public int difficulty;
    public float soundVolume;
    public float musicVolume;
    public string playerName;

    void Awake()
    {
        // Setup singleton
        if (instance != null && instance != gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    public void SaveData(SettingsData data)
    {
        GameData saveData = new GameData();
        saveData.difficulty = data.difficulty;
        saveData.soundVolume = data.soundVolume;
        saveData.musicVolume = data.musicVolume;
        saveData.playerName = data.playerName;

        DataPersistence.SaveGameData(saveData);

        // Store them in memory too for debugging purposes
        difficulty = data.difficulty;
        soundVolume = data.soundVolume;
        musicVolume = data.musicVolume;
        playerName = data.playerName;
    }
    public SettingsData LoadData()
    {
        GameData data = DataPersistence.LoadGameData();

        SettingsData settingsData = new SettingsData();
        settingsData.difficulty = data.difficulty;
        settingsData.soundVolume = data.soundVolume;
        settingsData.musicVolume = data.musicVolume;
        settingsData.playerName = data.playerName;

        // Load into memory too for debugging purposes
        difficulty = data.difficulty;
        soundVolume = data.soundVolume;
        musicVolume = data.musicVolume;
        playerName = data.playerName;

        return settingsData;
    }
}

