using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public SaveData data;

    string filePath;

    private void Awake()
    {
        instance = this;
        filePath = Application.persistentDataPath;
        if (PlayerPrefs.HasKey("SaveIndex"))
        {
            LoadFile(PlayerPrefs.GetInt("SaveIndex"));
        }
        else
        {
            LoadFile(1);
        }
    }

    public void Save()
    {
        data.playerInfo.x = PlayerMovements.instance.transform.position.x;
        data.playerInfo.y = PlayerMovements.instance.transform.position.y;

        data.playerInfo.score = PlayerMovements.instance.score;

        data.levelInfo.CoinsInfos.Clear();

        foreach (GameObject coin in LevelLoader.mInstance.mCoins)
        {
            ActorInfo actorInfo = new()
            {
                x = coin.transform.position.x,
                y = coin.transform.position.y
            };

            data.levelInfo.CoinsInfos.Add(actorInfo);
        }

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);

        if (!HasASave(PlayerPrefs.GetInt("SaveIndex")))
        {
            File.Create(filePath + "/game" + PlayerPrefs.GetInt("SaveIndex") + ".save").Dispose();
        }
        File.WriteAllText(filePath + "/game" + PlayerPrefs.GetInt("SaveIndex") + ".save", json);
    }

    public bool HasASave(int saveNumber)
    {
        return File.Exists(filePath + "/game" + saveNumber + ".save");
    }

    public void LoadFile(int saveNumber)
    {
        if (HasASave(saveNumber))
        {
            string json = File.ReadAllText(filePath + "/game" + saveNumber + ".save");
            data = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public void ResetFile()
    {
        File.Delete(filePath + "/game" + PlayerPrefs.GetInt("SaveIndex") + ".save");
    }
}
