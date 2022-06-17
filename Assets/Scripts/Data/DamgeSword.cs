using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamgeSword
{
    private float damge;

    public DamgeSword(float damgeS)
    {
        damge = damgeS;
    }

    public float GetDamge()
    {
        return damge;
    }
}