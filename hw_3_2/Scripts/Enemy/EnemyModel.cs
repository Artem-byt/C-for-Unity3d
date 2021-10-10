using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using interfaces;

namespace roll_a_ball
{
    public class EnemyModel: IEnemy
    {
        private GameObject _Enemy;
        private NavMeshAgent _EnemyNavMesh;
        private bool _StartSeed = false;
        private int _CurrentWayPoint = 0;
        private GameObject _Player;
        private Transform _Respawn;

        private Transform[] _Enemypoints { get; set; }

        public GameObject enemy { get { return _Enemy; } set { _Enemy = value; } }
        public Transform[] enemyPoints { get { return _Enemypoints; } set { _Enemypoints = value; } }
        public GameObject player { get { return _Player; } set { _Player = value; } }
        public Transform respawn { get { return _Respawn; } set { _Respawn = value; } }


        public void EnemyMovement()
        {
            if (_Enemy != null && _Enemy.TryGetComponent<NavMeshAgent>(out _EnemyNavMesh))
            {
                if (!_StartSeed)
                {
                    _EnemyNavMesh.SetDestination(_Enemypoints[0].position);
                    _StartSeed = true;
                }
                else
                {
                    if (_EnemyNavMesh.remainingDistance < _EnemyNavMesh.stoppingDistance)
                    {
                        _CurrentWayPoint = (_CurrentWayPoint + 1) % _Enemypoints.Length;
                        _EnemyNavMesh.SetDestination(_Enemypoints[_CurrentWayPoint].position);
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
}

