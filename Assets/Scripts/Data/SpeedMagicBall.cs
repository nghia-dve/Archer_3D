using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedMagicBall
{
    private float speedBall;

    public SpeedMagicBall(float speed)
    {
        speedBall = speed;
    }

    public float GetSpeed()
    {
        return speedBall;
    }
}

