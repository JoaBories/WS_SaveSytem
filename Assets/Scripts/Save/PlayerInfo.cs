using System;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public float x, y;
    public int score;

    public PlayerInfo()
    {
        x = 0;
        y = 0;
        score = 0;
    }
}
