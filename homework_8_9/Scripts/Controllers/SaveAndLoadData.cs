using System;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadData: ISaveAndLoad
{
    private Storage _storage;
    private GameData _gameData;
    private int _numberoflevel;

    public GameData GameData { get { return _gameData; } }

    public SaveAndLoadData()
    {
        _storage = new Storage();
        Load();
    }

    public void Save()
    {
        _gameData.NumberOfLevel = _numberoflevel;
        _storage.Save(_gameData);
        
    }

    public void Load()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        _numberoflevel = _gameData.NumberOfLevel;
    }


}
