using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInfo
{
    public List<ActorInfo> CoinsInfos;

    public LevelInfo()
    {
        CoinsInfos = new List<ActorInfo>();
    }
}
