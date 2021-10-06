using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInitialization : IInitialize
{
    private Transform _level;

    public LevelInitialization(ILevelFactory levelFactory, Vector3 position)
    {
        _level = levelFactory.CreateLevel(0);
        _level.position = position;
    }

    public void Initialize()
    {

    }

    public GameObject GetLvl()
    {
        return _level.gameObject;
    }

}
