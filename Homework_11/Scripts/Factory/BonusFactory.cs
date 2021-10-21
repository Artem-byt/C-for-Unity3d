using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFactory: IBonusFactory
{
    private GameObject[] _bonuses;
    private BonusInfo _bonusinfo;
    private List<Transform> _bonusObjects;

    public BonusFactory(string path)
    {
        _bonusinfo = Resources.Load<BonusInfo>(path);
        _bonuses = _bonusinfo.BonusPrefabs;
        _bonusObjects = new List<Transform>(8);
    }

    public List<Transform> CreateBonus()
    {
        int typeofbonus = 0;

        for (int i = 0; i < _bonusinfo.bonusRespawns.Length; i++)
        {
            
            _bonusObjects.Add(Object.Instantiate(_bonuses[typeofbonus]).transform);
            if(typeofbonus == 0)
            {
                _bonusObjects[i].gameObject.AddComponent<PositiveBonusIdentificator>();
            }
            else if (typeofbonus == 1)
            {
                _bonusObjects[i].gameObject.AddComponent<NegativeBonusIdentificator>();
            }
            else
            {
                _bonusObjects[i].gameObject.AddComponent<RequiredBonusIdentificator>();
            }
            _bonusObjects[i].position = _bonusinfo.bonusRespawns[i].position;
            typeofbonus = (typeofbonus + 1) % _bonuses.Length;
        }

        return _bonusObjects;
    }
}
