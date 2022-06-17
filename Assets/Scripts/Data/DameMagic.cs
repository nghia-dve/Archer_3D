using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DamgeMagic
{
    private float damge;

    public DamgeMagic(float damgeS)
    {
        damge = damgeS;
    }

    public float GetDamge()
    {
        return damge;
    }
}