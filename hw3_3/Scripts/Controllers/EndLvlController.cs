using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlController : IExecute
{

    private Transform _player;
    private Transform _endlvl;
    private Controllers _controllers;
    private LevelDestoyerInitialization _leveldestroy;

    public EndLvlController(Transform player, Transform endlvl, Controllers controllers, LevelDestoyerInitialization leveldestroy)
    {
        _player = player;
        _endlvl = endlvl;
        _controllers = controllers;
        _leveldestroy = leveldestroy;
    }
    public void Execute()
    {
        if (NumberofRequiredBonusUnits.GetUnit() == NumberofRequiredBonusUnits.GetCurrentUnit() && NumberofRequiredBonusUnits.GetCurrentUnit() != 0)
        {
            if (Vector3.Distance(_player.position, _endlvl.position) < 5f)
            {
                NumberofRequiredBonusUnits.ClearUnits();
                _controllers.CleanUp();
                _controllers.RemoveAll();
                _leveldestroy.DestroyAll();
                new GameInitialization(_controllers, 0);
                
            }
        }
    }
}
