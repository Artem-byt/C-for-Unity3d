using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : IExecute
{
    private IEnemyMove _enemymove;

    public EnemyMoveController(IEnemyMove enemymove)
    {
        _enemymove = enemymove;
    }

    public void Execute()
    {
        _enemymove.EnemyMoveToPoints();
    }
}
