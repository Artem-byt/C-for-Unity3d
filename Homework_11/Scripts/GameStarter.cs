using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private Controllers _controllers;

    void Start()
    {
        _controllers = new Controllers();
        new GameSatrtInitialization(_controllers);
        _controllers.Initialize();
    }


    void Update()
    {
        _controllers.Execute();
    }

    private void OnDestroy()
    {
        _controllers.CleanUp();
    }
}
