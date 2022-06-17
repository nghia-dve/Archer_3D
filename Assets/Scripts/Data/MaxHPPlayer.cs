using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MaxHPPlayer
{
    private int maxHP;

    public MaxHPPlayer(int maxHPPlayer)
    {
        maxHP = maxHPPlayer;
    }

    public int GetMaxHP()
    {
        return maxHP;
    }
}

