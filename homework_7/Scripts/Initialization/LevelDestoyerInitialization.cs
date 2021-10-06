using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestoyerInitialization
{
    private List<GameObject> _gameobjects;

    public LevelDestoyerInitialization(GameObject player, GameObject enemy, GameObject lvl, List<Transform> bonuses, GameObject canvas)
    {
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
        foreach (GameObject element in _gameobjects)
        {
            Object.DestroyImmediate(element);
        }
        _gameobjects.Clear();
        Debug.Log("”ничтожено");
    }
}
