using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSatrtInitialization
{

    public GameSatrtInitialization(Controllers controllers)
    {
        var startmenuinitialization = new StartMenuCanvasInitialization(new StartMenuCanvasFacroty(Resources.Load<StartMenuCanvasInfo>("StartMenuCanvas").canvasMenu));
        new StartLevelController(startmenuinitialization.GetButtons(), controllers, startmenuinitialization.GetStartMenu());
    }
}
