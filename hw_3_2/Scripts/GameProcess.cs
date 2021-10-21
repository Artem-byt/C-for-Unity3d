using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using roll_a_ball;

namespace roll_a_ball
{
    public class GameProcess
    {
        public PlayerController _controller { get; private set; }
        public PlayerModel _model { get; private set; }
        public GameView _view { get; private set; }

        public BonusModel _bonusmodel { get; private set; }
        public BonusController _bonuscontroller { get; private set; }

        public EnemyModel _enemyModel { get; private set; }
        public EnemyController _enemyController { get; private set; }
        public LvlCreator _lvlCreator { get; private set; }

        public void Run(GameObject gameobject)
        {
            this._lvlCreator = gameobject.GetComponent<LvlCreator>();
            this._lvlCreator.LevelGenerate(0, false);

            this._view = this._lvlCreator.player.GetComponent<GameView>();
            this._view.lvlCreator = this._lvlCreator;

            this._model = new PlayerModel();

            this._controller = new PlayerController(_model, _view);

            this._bonusmodel = new BonusModel();
            this._bonuscontroller = new BonusController(_bonusmodel, _view);

            this._enemyModel = new EnemyModel();
            this._enemyController = new EnemyController(_enemyModel, _view);
        }

        ~GameProcess() { }

    }
}

