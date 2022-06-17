using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HPPlayer 
{
    private int HP;

    public HPPlayer(int HPPlayer)
    {
        HP = HPPlayer;
    }

    public int GetHP()
    {
        return HP;
    }
}
