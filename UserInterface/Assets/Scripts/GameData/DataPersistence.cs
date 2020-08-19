using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class DataPersistence
{
    public const string SAVE_FILENAME = "MyGameData.data";

    public static void SaveGameData(GameData data)
    {
        string path = $"{Application.persistentDataPath}/${SAVE_FILENAME}";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = $"{Application.persistentDataPath}/${SAVE_FILENAME}";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log($"Game data file not found at path: ${path}");
            return null;
        }
    }
}
