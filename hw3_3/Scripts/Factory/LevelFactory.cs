using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : ILevelFactory
{
    private GameObject[] _level;

    public LevelFactory(GameObject[] levelprefab)
    {
        _level = levelprefab;
    }

    public Transform CreateLevel(int numberoflevel)
    {
        return Object.Instantiate(_level[numberoflevel]).transform;
    }
}
