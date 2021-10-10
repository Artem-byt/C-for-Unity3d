using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiredBonusController : IExecute
{
    private List<Transform> _positiveBonuses;
    private GameObject _player;

    public RequiredBonusController(List<Transform> bonuses, GameObject player)
    {
        _player = player;
        _positiveBonuses = new List<Transform>();

        for (int i = 0; i < bonuses.Count; i++)
        {
            if (bonuses[i].GetComponent<RequiredBonusIdentificator>())
            {
                _positiveBonuses.Add(bonuses[i]);
                NumberofRequiredBonusUnits.AddCurrentLvlUnit();
            }
        }
    }

    public void Execute()
    {
        for (int i = 0; i < _positiveBonuses.Count; i++)
        {
            if (Vector3.Distance(_player.transform.position, _positiveBonuses[i].position) < 2f)
            {
                Object.Destroy(_positiveBonuses[i].gameObject);
                _positiveBonuses.RemoveAt(i);
                NumberofRequiredBonusUnits.AddUnit();
            }

        }

    }
}
