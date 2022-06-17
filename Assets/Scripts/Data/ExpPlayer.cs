using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExpPlayer
{
    private float expPlayer;

    public ExpPlayer(float exp)
    {
        expPlayer = exp;
    }

    public float GetExp()
    {
        return expPlayer;
    }
}