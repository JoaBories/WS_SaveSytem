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
        data = new SaveData();
        filePath = Application.persistentDataPath + "/game.save";
    }

    private void Start()
    {
        LoadFile();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
    }

    public void Save()
    {
        data.playerInfo.x = PlayerMovements.instance.transform.position.x;
        data.playerInfo.y = PlayerMovements.instance.transform.position.y;

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
}
