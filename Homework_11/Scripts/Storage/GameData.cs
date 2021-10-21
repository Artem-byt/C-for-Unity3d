using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    private int _numberOfLevel;
    private Vector3 _position;

    public int NumberOfLevel { get { return _numberOfLevel; } set { _numberOfLevel = value; } }
    public Vector3 Position { get { return _position; } set { _position = value; } }

    public GameData()
    {
        _numberOfLevel = 0;
        _position = Vector3.zero;
    }
}
