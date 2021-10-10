using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : IEnemyMove
{
    private NavMeshAgent _navmeshagent;
    private Transform[] _enemypoints;
    private int _currentwaypoint;

    public EnemyMove(GameObject enemy, Transform[] points)
    {
        CheckComponents.CheckComponent<NavMeshAgent>(enemy);
        _navmeshagent = enemy.GetComponent<NavMeshAgent>();
        _enemypoints = points;
        _currentwaypoint = 0;
        _navmeshagent.SetDestination(_enemypoints[_currentwaypoint].position);
    }

    public void EnemyMoveToPoints()
    {
        if (_navmeshagent.remainingDistance < _navmeshagent.stoppingDistance)
        {
            _currentwaypoint = (_currentwaypoint + 1) % _enemypoints.Length;
            _navmeshagent.SetDestination(_enemypoints[_currentwaypoint].position);
        }
    }
}
