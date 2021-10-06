using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RequiredBonusController : IExecute
{
    

    private List<Transform> _positiveBonuses;
    private GameObject _player;
    private NumberofRequiredBonusUnits _numberofRequiredBonusUnits;
    private ICoinPick _bonusinitialization;

    public RequiredBonusController(List<Transform> bonuses, GameObject player, NumberofRequiredBonusUnits numberofRequiredBonusUnits, ICoinPick bonusInitialization)
    {
        _numberofRequiredBonusUnits = numberofRequiredBonusUnits;
        _player = player;
        _positiveBonuses = new List<Transform>();
        _bonusinitialization = bonusInitialization;

        for (int i = 0; i < bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<RequiredBonusIdentificator>())
            {
                _positiveBonuses.Add(bonuses[i]);
                _numberofRequiredBonusUnits.AddCurrentLvlUnit();
            }
        }
    }

    public void Execute()
    {
        for (int i = 0; i < _positiveBonuses.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _positiveBonuses[i].position) < 2f)
            {
                UnityEngine.Object.Destroy(_positiveBonuses[i].gameObject);
                _positiveBonuses.RemoveAt(i);
                _numberofRequiredBonusUnits.AddUnit();
                _bonusinitialization.ChangeCoin(1);
            }

        }

    }
}
