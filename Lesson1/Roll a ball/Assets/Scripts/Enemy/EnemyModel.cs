using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel
{
    private GameObject _Enemy;
    private NavMeshAgent _EnemyNavMesh;
    private bool _StartSeed = false;
    private int _CurrentWayPoint = 0;
    private GameObject _Player;
    private GameObject _Respawn;
    
    private GameObject[] _Enemypoints { get; set; }

    public GameObject enemy { get { return _Enemy; } set { _Enemy = value; } }
    public GameObject[] enemyPoints { get { return _Enemypoints; } set { _Enemypoints = value; } }
    public GameObject player { get { return _Player; } set { _Player = value; } }
    public GameObject respawn { get { return _Respawn; } set { _Respawn = value; } }


    public void EnemyMovement()
    {
       if(_Enemy.TryGetComponent<NavMeshAgent>(out _EnemyNavMesh))
        {
            if (!_StartSeed)
            {
                _EnemyNavMesh.SetDestination(_Enemypoints[0].transform.position);
                _StartSeed = true;
            }
            else
            {
                if (_EnemyNavMesh.remainingDistance < _EnemyNavMesh.stoppingDistance)
                {
                    _CurrentWayPoint = (_CurrentWayPoint + 1) % _Enemypoints.Length;
                    _EnemyNavMesh.SetDestination(_Enemypoints[_CurrentWayPoint].transform.position);
                }
            }
        }
    }

    public void PlayerCatched()
    {
        player.transform.position = respawn.transform.position;
    }

    ~EnemyModel() { }
}
