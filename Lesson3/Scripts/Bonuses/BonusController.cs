using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball;

namespace roll_a_ball
{
    public class BonusController
    {
        private BonusModel _BonusModel { get; set; }
        private GameView _gameview { get; set; }

        public BonusController(BonusModel _model, GameView _view)
        {
            _BonusModel = _model;
            _gameview = _view;

            _gameview.MovingSpeedPlayer += new GameView.MovingSpeedDataPlayer(DoUpdate);
            _gameview.MovingSetSpeedPlayer += new GameView.MovingSetDefaultSpeedPlayer(SetSpeedDefault);
        }

        public void DoUpdate(object value)
        {
            _BonusModel.numberOfRequiredBonuses = _gameview.lvlCreator.NumberOfRequiredBonuses;
            _BonusModel.gameObjectPlayer = _gameview.GameObjectPlayer;
            _BonusModel.typeofBonus = _gameview.TypeofBonus;
            _BonusModel.BonusEffect(_gameview.Speed);
            _gameview.Speed = _BonusModel.speed;
        }
        public void SetSpeedDefault(object value)
        {
            _gameview.Speed = 1f;
            _BonusModel.speed = 1f;
        }

        ~BonusController()
        {
            _gameview.MovingSpeedPlayer -= new GameView.MovingSpeedDataPlayer(DoUpdate);
        }
    }

}
