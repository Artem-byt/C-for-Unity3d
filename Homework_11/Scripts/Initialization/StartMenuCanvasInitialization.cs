using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartMenuCanvasInitialization: ICanvasStartMenuButtons
{
    private GameObject _startMenu;
    private List<Button> _buttons;

    public StartMenuCanvasInitialization(ICreateCanvasStartMenu createCanvasStartMenu)
    {
        _buttons = new List<Button>();
        _startMenu = createCanvasStartMenu.CreateSatrtMenuCanvas();
        _buttons.AddRange(_startMenu.GetComponentsInChildren<Button>());
    }

    public GameObject GetStartMenu()
    {
        return _startMenu;
    }

    public List<Button> GetButtons()
    {
        return _buttons;
    }
}
