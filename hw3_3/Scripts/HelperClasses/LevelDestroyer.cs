using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelDestroyer
{
    private static List<GameObject> _gameobjects;

    public static void Initialize()
    {
        _gameobjects = new List<GameObject>();
    }

    public static void AddGameObject(GameObject gameObject)
    {
        _gameobjects.Add(gameObject);
    }

    public static void DestroyAll()
    {
        for (int i = 0; i < _gameobjects.Count; i++)
        {
            Object.DestroyImmediate(_gameobjects[i]);
        }
        _gameobjects.Clear();
        Debug.Log("”ничтожено");
    }
}
