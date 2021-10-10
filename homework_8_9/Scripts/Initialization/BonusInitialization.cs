using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BonusInitialization : IInitialize, IGetBonuses, ICoinPick
{
    public event Action<int> OnBonusPickedUp = delegate (int coin) { };
    private List<Transform> _bonuses;

    public BonusInitialization(IBonusFactory bonusfactory)
    {
        _bonuses = bonusfactory.CreateBonus();
    }

    public void Initialize()
    {

    }

    public void ChangeCoin(int coin)
    {
        OnBonusPickedUp?.Invoke(coin);
    }

    public List<Transform> GetBonuses()
    {
        return _bonuses;
    }
}
