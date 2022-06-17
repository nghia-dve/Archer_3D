using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelPlayer 
{
    private int levelPlayer;

    public LevelPlayer(int level)
    {
        levelPlayer = level;
    }

    public int GetLevel()
    {
        return levelPlayer;
    }
}

