using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball;

namespace roll_a_ball
{
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
            _model.speed = _view.Speed;
            _model.direction = _view.Direction;
            _model.xMouse = _view.XMouse;
            _model.yMouse = _view.YMouse;
            _model.mouseScrollWheel = _view.MouseScrollWheel;
            _model.Move(_view.GameObjectPlayer);
            _model.CameraMove(_view.GameObjectCamera, _view.GameObjectPlayer);
        }

        ~PlayerController()
        {
            _view.MovingPlayer -= new GameView.MovingDataPlayer(DoUpdate);
        }

    }
}

