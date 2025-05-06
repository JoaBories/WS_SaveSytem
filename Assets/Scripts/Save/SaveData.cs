using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public PlayerInfo playerInfo;
    public LevelInfo levelInfo;

    public SaveData() 
    {
        playerInfo = new PlayerInfo();
        levelInfo = new LevelInfo();
    }
}
