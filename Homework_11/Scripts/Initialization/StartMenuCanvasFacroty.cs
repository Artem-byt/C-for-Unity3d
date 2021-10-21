using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuCanvasFacroty: ICreateCanvasStartMenu
{
    private List<GameObject> _canvasMenu;
    public StartMenuCanvasFacroty(List<GameObject> gameObjects)
    {
        _canvasMenu = gameObjects;
    }

    public GameObject CreateSatrtMenuCanvas()
    {
        return Object.Instantiate(_canvasMenu[0]);
    }


}
