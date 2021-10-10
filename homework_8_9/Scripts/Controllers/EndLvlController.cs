using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLvlController : IExecute
{

    private Transform _player;
    private Transform _endlvl;
    private Controllers _controllers;
    private LevelDestoyerInitialization _leveldestroy;
    private NumberofRequiredBonusUnits _numberofRequiredBonusUnits;

    public EndLvlController(Transform player, Transform endlvl, Controllers controllers, LevelDestoyerInitialization leveldestroy, NumberofRequiredBonusUnits numberofRequiredBonusUnits)
    {
        _numberofRequiredBonusUnits = numberofRequiredBonusUnits;
        _player = player;
        _endlvl = endlvl;
        _controllers = controllers;
        _leveldestroy = leveldestroy;
    }
    public void Execute()
    {
        if (_numberofRequiredBonusUnits.GetUnit() == _numberofRequiredBonusUnits.GetCurrentUnit() && _numberofRequiredBonusUnits.GetCurrentUnit() != 0)
        {
            if ((_player.position - _endlvl.position).sqrMagnitude < 25f)
            {
                _numberofRequiredBonusUnits.ClearUnits();
                _controllers.CleanUp();
                _controllers.RemoveAll();
                _leveldestroy.DestroyAll();
                new GameInitialization(_controllers, 0);
                
            }
        }
    }
}
