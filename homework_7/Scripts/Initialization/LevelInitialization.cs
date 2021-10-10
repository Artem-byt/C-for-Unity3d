using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelInitialization : IInitialize
{
    private Transform _level;

    public LevelInitialization(ILevelFactory levelFactory, Vector3 position, SaveAndLoadData saveAndLoadData)
    {
        
        _level = levelFactory.CreateLevel(saveAndLoadData.GameData.NumberOfLevel);
        CheckComponents.CheckComponent<NavMeshSurface>(_level.gameObject);
        _level.position = position;
    }

    public void Initialize()
    {

    }

    public GameObject GetLvl()
    {
        return _level.gameObject;
    }

    public NavMeshSurface GetNavMeshSurface()
    {
        return _level.GetComponent<NavMeshSurface>();
    }
}
