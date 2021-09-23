using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess
{
    public PlayerController _controller { get; private set; }
    public PlayerModel _model { get; private set; }
    public GameView _view { get; private set; }

    public BonusModel _bonusmodel { get; private set; }
    public BonusController _bonuscontroller { get; private set; }

    public EnemyModel _enemyModel { get; private set; }
    public EnemyController _enemyController { get; private set; }

    private string Player = nameof(Player);
    private GameObject _player;


    public void Run()
    {
        _player = GameObject.FindGameObjectWithTag(Player);
        this._view = _player.GetComponent<GameView>();

        this._model = new PlayerModel();
        
        this._controller = new PlayerController(_model, _view);

        this._bonusmodel = new BonusModel();
        this._bonuscontroller = new BonusController(_bonusmodel, _view);

        this._enemyModel = new EnemyModel();
        this._enemyController = new EnemyController(_enemyModel, _view);
    }

    ~GameProcess() { }

}
