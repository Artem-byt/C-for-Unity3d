using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitialization : IInitialize, IGetEnemy
{
    private Transform _enemy;
    private EnemyMove _enemymove;

    public EnemyInitialization(IEnemyFactory enemy)
    {
        _enemy = enemy.CreateEnemy();
        _enemymove = new EnemyMove(_enemy.gameObject, Resources.LoadAll<PointsInfo>("")[0].points);
    }

    public GameObject GetEnemy()
    {
        return _enemy.gameObject;
    }

    public IEnemyMove MoveEnemy()
    {
        return _enemymove;
    }

    public void Initialize()
    {

    }
}
