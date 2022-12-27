using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitType;
using UpgradeClass;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveAndLoad
{
    public static void SaveSettings(SettingsMenu settings)
    {

    }

    public static void Save(ScoreHandler scoreHandler, UpgradeHandler upgradeHandler)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bennyClickerData.swerve";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(scoreHandler, upgradeHandler);

        formatter.Serialize(stream, data);
        stream.Close();
    }
        
    public static GameData Load()
    {
        string path = Application.persistentDataPath + "/bennyClickerData.swerve";
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
            Debug.LogError("No Save file found in " + path + " :(");
            return null;
        }
    }
}