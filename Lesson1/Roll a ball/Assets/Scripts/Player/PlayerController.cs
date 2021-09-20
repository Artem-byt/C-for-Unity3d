using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerModel _model { get; set; }
    private GameView _view { get; set; }

    

    public PlayerController(PlayerModel model, GameView view)
    {
        _model = model;
        _view = view;

        _view.MovingPlayer += new GameView.MovingDataPlayer(DoUpdate);
    }


    public void DoUpdate(object value)
    {
        _model.speed = _view.speed;
        _model.direction = _view.direction;
        _model.xMouse = _view.xMouse;
        _model.yMouse = _view.yMouse;
        _model.mouseScrollWheel = _view.mouseScrollWheel;
        _model.Move(_view.gameObjectPlayer);
        _model.CameraMove(_view.gameObjectCamera, _view.gameObjectPlayer);
    }

    ~PlayerController() 
    {
        _view.MovingPlayer -= new GameView.MovingDataPlayer(DoUpdate);
    }

}
