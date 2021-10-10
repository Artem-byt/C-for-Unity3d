using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball;

namespace roll_a_ball
{
    public class EnemyController
    {
        public EnemyModel _enemyModel { get; set; }
        public GameView _view { get; set; }

        private bool _flagreadrespandplayer = false;

        public EnemyController(EnemyModel _model, GameView view)
        {
            _enemyModel = _model;
            _view = view;

            _view.LevelWorkforEnemy += new GameView.LevelWork(DoUpdateEnemy);
            _view._playercatched += new GameView.PlayerCatch(UpDateRespawnPlayerCatched);
        }

        public void DoUpdateEnemy(object value)
        {
            _enemyModel.enemy = _view.lvlCreator.enemy;
            _enemyModel.enemyPoints = _view.lvlCreator.enemyPoints;
            _enemyModel.EnemyMovement();
        }

        public void UpDateRespawnPlayerCatched(object value)
        {
            if (!_flagreadrespandplayer)
            {
                _enemyModel.player = _view.GameObjectPlayer;
                _enemyModel.respawn = _view.lvlCreator.startLevel;
                _flagreadrespandplayer = true;
            }

            _enemyModel.PlayerCatched();
        }

        ~EnemyController()
        {
            _view.LevelWorkforEnemy -= new GameView.LevelWork(DoUpdateEnemy);
            _view._playercatched -= new GameView.PlayerCatch(UpDateRespawnPlayerCatched);
        }
    }
}

