using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedSpawnMagicBall
{
    private int speedSpawn;

    public SpeedSpawnMagicBall(int speed)
    {
        speedSpawn = speed;
    }

    public int GetSpeed()
    {
        return speedSpawn;
    }
}

