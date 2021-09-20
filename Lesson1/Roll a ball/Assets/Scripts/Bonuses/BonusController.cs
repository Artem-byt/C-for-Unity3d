using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController
{
    private BonusModel _BonusModel { get; set; }
    private GameView _gameview { get; set; }

    public BonusController(BonusModel _model, GameView _view)
    {
        _BonusModel = _model;
        _gameview = _view;

        _gameview.MovingSpeedPlayer += new GameView.MovingSpeedDataPlayer(DoUpdate);
    }

    public void DoUpdate(object value)
    {
        _BonusModel.positiveBonuses = _gameview.positiveBonuses;
        _BonusModel.negativeBonuses = _gameview.negativeBonuses;
        _BonusModel.requiredBonuses = _gameview.requiredBonuses;
        _BonusModel.collisionGameOgject = _gameview.collisionGameOgject;
        _BonusModel.gameObjectPlayer = _gameview.gameObjectPlayer;
        _BonusModel.typeofBonus = _gameview.typeofBonus;
        _BonusModel.BonusEffect();
        _gameview.speed = _BonusModel.speed;
    }

    ~BonusController()
    {
        _gameview.MovingSpeedPlayer -= new GameView.MovingSpeedDataPlayer(DoUpdate);
    }
}
