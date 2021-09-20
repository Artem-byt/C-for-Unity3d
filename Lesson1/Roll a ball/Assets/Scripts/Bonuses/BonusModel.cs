using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEngine.Debug;

public class BonusModel
{
    private GameObject[] _PositiveBonuses { get; set; }
    private GameObject[] _NegativeBonuses { get; set; }

    private GameObject[] _ReqiuredBonuses { get; set; }
    private GameObject _CollisionGameObject { get; set; }
    private GameObject _gameObjectPlayer { get; set; }

    private float _SpeedPlayer { get; set; } = 1f;

    private string PositiveBonus = nameof(PositiveBonus);
    private string NegativeBonus = nameof(NegativeBonus);
    private string RequiredBonus = nameof(RequiredBonus);
    private string _TypeofBonus;
    private int _RequiredBonusCounter = 0;
    private bool _WinCondition = false;

    public string typeofBonus { get { return _TypeofBonus; } set { _TypeofBonus = value; } }
    public float speed { get { return _SpeedPlayer; } set { _SpeedPlayer = value; } }

    public GameObject gameObjectPlayer { get { return _gameObjectPlayer; } set { _gameObjectPlayer = value; } }

    public GameObject[] positiveBonuses { get { return _PositiveBonuses; } set { _PositiveBonuses = value; } }
    public GameObject[] negativeBonuses { get { return _NegativeBonuses; } set { _NegativeBonuses = value; } }
    public GameObject[] requiredBonuses { get { return _ReqiuredBonuses; } set { _ReqiuredBonuses = value; } }

    public GameObject collisionGameOgject
    {
        get { return _CollisionGameObject; }
        set { _CollisionGameObject = value; }
    }


    public void BonusEffect()
    {
        
        if (_TypeofBonus == PositiveBonus) PositiveEffect();
        else if (_TypeofBonus == NegativeBonus) NegativeEffect();
        else if (_TypeofBonus == RequiredBonus)
        {
            _RequiredBonusCounter++;
            if (_RequiredBonusCounter == _ReqiuredBonuses.Length)
            {
                _WinCondition = true;
                Log("Exit was opened");
                Log(_SpeedPlayer);
            }
        }
    }

    public void NegativeEffect()
    {
        //проверяем какой индекс у бонуса и в зависимости от индекса даем плюшку, пока что только буст скорости
        if (Array.IndexOf(_NegativeBonuses, _CollisionGameObject) == 0)
        {
            _SpeedPlayer = 0.9f;
        }
    }

    public void PositiveEffect()
    {
        //проверяем какой индекс у бонуса и в зависимости от индекса даем плюшку, пока что только анбуст скорости
        if (Array.IndexOf(_PositiveBonuses, _CollisionGameObject) == 0)
        {
            _SpeedPlayer = 5f;
        }
    }

    ~BonusModel() { }

}
