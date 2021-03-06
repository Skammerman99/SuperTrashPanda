﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyBase{

    public string Name;
    public float BaseHP;
    public float CurHP;
    public float BaseMP;
    public float CurMP;
    public int Strength;
    public int Dexterity;
    public int Intellect;
    public int Defense;
    public int Resistance;

    public enum Type
    {
        NEUTRAL,
        FIRE,
        WATER
    }

    public Type EnemyType;

    public List<AttackBase> Attacks = new List<AttackBase>();
   
}
