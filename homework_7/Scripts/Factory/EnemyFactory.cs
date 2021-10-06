using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private GameObject _enemy;

    public EnemyFactory(GameObject enemyprefab)
    {
        _enemy = enemyprefab;
    }

    public Transform CreateEnemy()
    {
        return Object.Instantiate(_enemy).transform;
    }
}
