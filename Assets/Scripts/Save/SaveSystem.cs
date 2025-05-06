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
        filePath = Application.persistentDataPath + "/game.save";
        LoadFile();
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

        if (!HasASave())
        {
            File.Create(filePath).Dispose();
        }
        File.WriteAllText(filePath, json);
    }

    public bool HasASave()
    {
        return File.Exists(filePath);
    }

    public void LoadFile()
    {
        if (HasASave())
        {
            string json = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<SaveData>(json);
        }
    }

    public void ResetFile()
    {
        File.Delete(filePath);
    }
}
