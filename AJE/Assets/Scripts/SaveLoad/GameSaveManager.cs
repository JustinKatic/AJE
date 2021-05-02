using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;

    public BoolVariableList unlockedLevels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance = this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    
        //LoadGame(unlockedLevels, "unlockedLevels");
    }



    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    public bool DoesSaveFileExist(string fileName)
    {
        return (File.Exists(Application.persistentDataPath + "/game_save/" + fileName + ".txt"));
    }


    public void SaveGame<T>(T objectToSave, string fileName)
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_save/" + fileName + ".txt");
        var json = JsonUtility.ToJson(objectToSave);
        bf.Serialize(file, json);
    }

    public void LoadGame<T>(T objectToLoad, string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/game_save/" + fileName + ".txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/" + fileName + ".txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), objectToLoad);
            file.Close();
        }
    }
}
