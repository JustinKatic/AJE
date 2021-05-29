using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;

    public BoolVariableList unlockedLevels;



    public int levelNeededUnlockedFor4Souls;
    public int levelNeededUnlockedFor6Souls;
    public int levelNeededUnlockedFor8Souls;


    [SerializeField] FloatVariable playerCurrency;
    public IntVariable purchasedSouls;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);


        if (unlockedLevels.boolList[levelNeededUnlockedFor8Souls - 1].locked == false)
        {
            playerCurrency.Value = 8;
            playerCurrency.RuntimeValue = playerCurrency.Value + purchasedSouls.Value;
        }
        else if (unlockedLevels.boolList[levelNeededUnlockedFor6Souls - 1].locked == false)
        {
            playerCurrency.Value = 6;
            playerCurrency.RuntimeValue = playerCurrency.Value + purchasedSouls.Value;

        }
        else if (unlockedLevels.boolList[levelNeededUnlockedFor4Souls - 1].locked == false)
        {
            playerCurrency.Value = 4;
            playerCurrency.RuntimeValue = playerCurrency.Value + purchasedSouls.Value;
        }
        else
        {
            playerCurrency.Value = 2;
            playerCurrency.RuntimeValue = playerCurrency.Value + purchasedSouls.Value;
        }
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
