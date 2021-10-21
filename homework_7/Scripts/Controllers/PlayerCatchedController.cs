using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatchedController : IExecute
{
    private Transform _player;
    private Transform _enemy;
    private Transform _startLevel;

    public PlayerCatchedController(IGetPlayer player, IGetEnemy enemy)
    {
        _player = player.GetPlayer().transform;
        _enemy = enemy.GetEnemy().transform;
        _startLevel = Resources.Load<PointsInfo>("StartAndEndPoints").points[0];
    }

    public void Execute()
    {
        if (Vector3.Distance(_player.position, _enemy.position) < 2f)
        {
            _player.position = _startLevel.position;
        }
    }
}
