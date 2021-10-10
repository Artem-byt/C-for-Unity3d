using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestoyerInitialization: IInitialize
{
    private List<GameObject> _gameobjects;
    private List<RadarObject> _radarObjects;

    public LevelDestoyerInitialization(GameObject player, GameObject enemy, GameObject lvl, List<Transform> bonuses, GameObject canvas, List<RadarObject> radarObjects)
    {
        _radarObjects = radarObjects;
        _gameobjects = new List<GameObject>();
        _gameobjects.Add(player);
        _gameobjects.Add(enemy);
        _gameobjects.Add(lvl);
        _gameobjects.Add(canvas);
        foreach (Transform element in bonuses)
        {
            _gameobjects.Add(element.gameObject);
        }
    }

    public void DestroyAll()
    {
        _radarObjects.Clear();
        foreach (GameObject element in _gameobjects)
        {
            Object.DestroyImmediate(element);
        }
        _gameobjects.Clear();
        Debug.Log("”ничтожено");
    }

    public void Initialize()
    {

    }
}
