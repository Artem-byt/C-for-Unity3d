using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelController 
{
    private List<Button> _buttonStart;
    private Controllers _controllers;
    private GameObject _startCanvas;

    public StartLevelController(List<Button> buttons, Controllers controllers, GameObject startcanvas)
    {
        _startCanvas = startcanvas;
        _controllers = controllers;
        _buttonStart = buttons;

        foreach(var element in _buttonStart)
        {
            element.onClick.AddListener(SetLevel);
        }
    }

    private void SetLevel()
    {
        _startCanvas.SetActive(false);
        new GameInitialization(_controllers, 0);
    }
}
