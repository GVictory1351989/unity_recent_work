﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Entity
{
    public int EntityID { get; private set; }
    public string EntityType { get; private set; }
    public Entity(int id, string type)
    {
        EntityID = id;
        EntityType = type;
    }
    public Dictionary<(string,int), object> Components = new();
}
