﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData
{
    private int xp;
    private int requiredXp;
    private int levelBase;
    private int lvl;


    public int Xp
    {
        get { return xp; }
    }

    public int RequiredXp
    {
        get { return requiredXp; }
    }

    public int LevelBase 
    {
        get { return levelBase; }
    }

    public int Lvl
    {
        get { return lvl; }
    }




    public PlayerData(Player player)
    {
        xp = player.Xp;
        requiredXp = player.RequiredXp;
        levelBase = player.LevelBase;
        lvl = player.Lvl;
        


    }
}
