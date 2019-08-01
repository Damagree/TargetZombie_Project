﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class PlayerData
{
    public static PlayerData current;
    public int score;
    public string username;

    public PlayerData(string name)
    {
        score = PlayerStats.Score;
        username = name;
    }
    public PlayerData()
    {
        score = PlayerStats.Score;
        username ="Null";
    }
  
}