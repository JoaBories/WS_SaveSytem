using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public PlayerInfo playerInfo;

    public SaveData() 
    {
        playerInfo = new PlayerInfo();
    }
}
