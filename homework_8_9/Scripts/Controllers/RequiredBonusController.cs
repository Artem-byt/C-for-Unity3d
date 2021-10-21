using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RequiredBonusController : IExecute
{
    private List<Transform> _requiredBonuses;
    private GameObject _player;
    private NumberofRequiredBonusUnits _numberofRequiredBonusUnits;
    private ICoinPick _bonusinitialization;
    private IRadarDeleteIcon _radardeleteIcon;

    private const float distancebetweenplayerandbonus = 4f;

    public RequiredBonusController(List<Transform> bonuses, GameObject player, NumberofRequiredBonusUnits numberofRequiredBonusUnits, ICoinPick bonusInitialization, IRadarDeleteIcon radarDeleteIcon)
    {
        _radardeleteIcon = radarDeleteIcon;
        _numberofRequiredBonusUnits = numberofRequiredBonusUnits;
        _player = player;
        _requiredBonuses = new List<Transform>();
        _bonusinitialization = bonusInitialization;

        for (int i = 0; i < bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<RequiredBonusIdentificator>())
            {
                _requiredBonuses.Add(bonuses[i]);
                _numberofRequiredBonusUnits.AddCurrentLvlUnit();
            }
        }
    }

    public void CheckBonusDistance()
    {
        for (int i = 0; i < _requiredBonuses.Count; i++)
        {
            if ((_player.transform.position -_requiredBonuses[i].position).magnitude < distancebetweenplayerandbonus)
            {
                _radardeleteIcon.GetDelete(_requiredBonuses[i].gameObject);
                UnityEngine.Object.Destroy(_requiredBonuses[i].gameObject);
                _requiredBonuses.RemoveAt(i);
                _numberofRequiredBonusUnits.AddUnit();
                _bonusinitialization.ChangeCoin(1);
            }

        }
    }

    public void Execute()
    {
        CheckBonusDistance();
    }
}
