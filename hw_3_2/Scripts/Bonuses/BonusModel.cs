using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static UnityEngine.Debug;
using interfaces;

namespace roll_a_ball
{
    public class BonusModel: IBonus
    {
        private GameObject _gameObjectPlayer;
        private float _SpeedPlayer = 1f;

        private int _TypeofBonus;
        private int _RequiredBonusCounter = 0;
        private bool _WinCondition = false;
        private int _NumberOfRequiredBonuses;

        public int typeofBonus { get { return _TypeofBonus; } set { _TypeofBonus = value; } }
        public float speed { get { return _SpeedPlayer; } set { _SpeedPlayer = value; } }
        public int numberOfRequiredBonuses { get { return _NumberOfRequiredBonuses; } set { _NumberOfRequiredBonuses = value; } }

        public GameObject gameObjectPlayer { get { return _gameObjectPlayer; } set { _gameObjectPlayer = value; } }



        public void BonusEffect(float currentspeed)
        {

            if (_TypeofBonus == 0) PositiveEffect();
            else if (_TypeofBonus == 1) NegativeEffect();
            else if (_TypeofBonus == 2)
            {
                _RequiredBonusCounter++;
                if (_RequiredBonusCounter == _NumberOfRequiredBonuses)
                {
                    _SpeedPlayer = currentspeed;
                    _WinCondition = true;
                    Log("Exit was opened");
                }
            }
        }

        public void NegativeEffect()
        {
            _SpeedPlayer = 0.5f;
        }

        public void PositiveEffect()
        {
            _SpeedPlayer = 5f;
        }



        ~BonusModel() { }

    }
}

